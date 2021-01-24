    [TestMethod]
        public void QuoraLogin()
        {
            ChromeDriver webDriver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 0, 30));
            webDriver.Navigate().GoToUrl("https://www.quora.com/");
            IWebElement email= wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='login']//input[@name='email']")));
            email.SendKeys("ABC@yahoo.com");
            IWebElement password = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='login']//input[@name='password']")));
            password.SendKeys("123");
            webDriver.FindElement(By.XPath("//div[@class='login']//input[@value='Login']")).Click();
        }
