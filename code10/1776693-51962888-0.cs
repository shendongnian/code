    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Support.UI;
    
    namespace WebRole1.Controllers
    {
        public class PhantomController : ApiController
        {
            /// <summary>
            /// Run PhantomJS UI tests against the specified URL
            /// </summary>
            /// <param name="URL">URL to test</param>
            public string Get(string URL)
            {
                string result = UITests.Test(URL);
                return result;
            }
        }
    
        /// <summary>
        /// UITests class
        /// </summary>
        public class UITests
        {
            /// <summary>
            /// Test implementation
            /// </summary>
            /// <param name="URL">URL to test</param>
            /// <returns></returns>
            public static string Test(string URL)
            {
                // Initialize the Chrome Driver
                // Place phantomjs.exe driver in the project root,
                // meaning same folder as WebRole.cs
                using (var driver = new PhantomJSDriver())
                {
                    try
                    {
                        // Go to the home page
                        driver.Navigate().GoToUrl(URL);
    
                        IWebElement input;
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
    
                        Func<IWebDriver, IWebElement> _emailInputIsVisible =
                            ExpectedConditions.ElementIsVisible(By.Id("email"));
                        wait.Until(_emailInputIsVisible);
                        input = driver.FindElementById("email");
                        input.SendKeys("imposter@mailinator.com");
                        driver.FindElementById("submit").Click();
                        var alertbox = driver.FindElementById("alert");
                        if (alertbox.Text.Contains("disposable"))
                        {
                            return "TEST_PASS";
                        }
                        else
                        {
                            return "TEST_FAIL: alertbox.Text should contain word 'disposable'";
                        }
                    }
    
                    catch (Exception ex)
                    {
                        return $"TEST_FAIL: {ex.Message}";
                    }
                }
            }
        }
    }
    
