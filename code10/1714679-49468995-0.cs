    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    
    namespace SeleniumWebAutomation
    {
        public class WebElementWait : DefaultWait<IWebElement>
        {       
            public WebElementWait(IWebElement element, TimeSpan timeout) : base(element, new SystemClock())
            {
                this.Timeout = timeout;
                this.IgnoreExceptionTypes(typeof(NotFoundException));
            }
        }
    
        public static class WebDriverExtension
        {
            public static void WaitAndClick(this IWebDriver driver, Func<IWebDriver,IWebElement> condition,TimeSpan timeSpan)
            {
                IWebElement webElement = new WebDriverWait(driver, timeSpan).Until(condition);
                webElement.Click();
            }
        }
    }
  
         
