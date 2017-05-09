using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test1
    {
        
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demowebshop.tricentis.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void The1Test()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.LinkText("Register")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gender-male")));
            driver.FindElement(By.Id("gender-male")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FirstName")));
            driver.FindElement(By.Id("FirstName")).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FirstName")));
            driver.FindElement(By.Id("FirstName")).SendKeys("Ivan");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("LastName")));
            driver.FindElement(By.Id("LastName")).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("LastName")));
            driver.FindElement(By.Id("LastName")).SendKeys("Maric");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            driver.FindElement(By.Id("Email")).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            driver.FindElement(By.Id("Email")).SendKeys(finalString + "imaric@etfos.hr");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));
            driver.FindElement(By.Id("Password")).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ConfirmPassword")));
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ConfirmPassword")));
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register-button")));
            driver.FindElement(By.Id("register-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.register-continue-button")));
            driver.FindElement(By.CssSelector("input.button-1.register-continue-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pollanswers-2")));
            driver.FindElement(By.Id("pollanswers-2")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("vote-poll-1")));
            driver.FindElement(By.Id("vote-poll-1")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(finalString + "imaric@etfos.hr")));
            driver.FindElement(By.LinkText(finalString+"imaric@etfos.hr")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FirstName")));
            driver.FindElement(By.Id("FirstName")).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FirstName")));
            driver.FindElement(By.Id("FirstName")).SendKeys("Ivana");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gender-female")));
            driver.FindElement(By.Id("gender-female")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("save-info-button")));
            driver.FindElement(By.Name("save-info-button")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
