    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    
    namespace SeleniumDemo
    {
        class Program
        {
            private static IWebDriver webDriver;
            private static TimeSpan defaultWait = TimeSpan.FromSeconds(10);
            private static String targetUrl = "http://www.oddsportal.com/matches/soccer/20180701/";
            private static String driversDir = @"../../Drivers/";
    
            static void Main(string[] args)
            {
                webDriver = new ChromeDriver(driversDir);
                webDriver.Navigate().GoToUrl(targetUrl);
                IWebElement table = webDriver.FindElement(By.Id("table-matches"));
                var innerHtml = table.GetAttribute("innerHTML");
            }
    
            #region (!) I didn't even use this, but it can be useful (!)
            public static IWebElement FindElement(By by)
            {
                try
                {
                    WaitForAjax();
                    var wait = new WebDriverWait(webDriver, defaultWait);
                    return wait.Until(driver => driver.FindElement(by));
                }
                catch
                {
                    return null;
                }
            }
    
            public static void WaitForAjax()
            {
                var wait = new WebDriverWait(webDriver, defaultWait);
                wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
            }
            #endregion
        }
    }
