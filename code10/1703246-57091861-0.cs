    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;
    
    public class GoogleLoginPage : BasePageObject
        {
            public GoogleLoginPage(IWebDriver driver) : base(driver) { }
    
            const string _url = "https://accounts.google.com/ServiceLogin";
    
            [FindsBy(How = How.Id, Using = "identifierId")]
            IWebElement GoogleInput { get; set; }
    
            [FindsBy(How = How.CssSelector, Using = "[id='identifierNext']")]
            IWebElement GoogleButton { get; set; }
    
            [FindsBy(How = How.CssSelector, Using = "[name='password']")]
            IWebElement GooglePassInput { get; set; }
    
            [FindsBy(How = How.CssSelector, Using = "[id='passwordNext']")]
            IWebElement GooglePassButton { get; set; }
    
            public void LoginAccountGoogleSitePage()
            {
                _driver.Navigate().GoToUrl(_url);
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                wait.Until(d => GoogleLoginInput.Displayed);
                GoogleInput.SendKeys("mail@gmail.com");
                GoogleButton.Click();
                GooglePassInput.SendKeys("password123");
                GooglePassButton.Click();
            }
    
        }
