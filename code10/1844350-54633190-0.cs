    [OneTimeSetUp]
        public void initalise()
        {  //Maximise Window
            driver.Manage().Window.Maximize();
            //Navigates to the NG Test DB
            driver.Url = "https://TESTWEBSITE.co.uk";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Find Company Text Box and send company name
            driver.FindElement(By.XPath("//input[@id='txtCompany']")).SendKeys("CompanyName");
            //Find username Text Box and send username
            driver.FindElement(By.XPath("//input[@id='txtUsername']")).SendKeys("6969_1");
            //Find password and send
            driver.FindElement(By.XPath("//input[@id='txtPassword']")).SendKeys("Password!");
            //Find Login button and click
            driver.FindElement(By.XPath("//input[@id='cmdLogin']")).Click();
        }
     [Test, Order(1)]
        public void reportsStandard()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//span[@class='rpOut']//span[@class='rpText'][contains(text(),'Reports')]")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Standard Reports')]")).Click();
            IWebElement ReportType = driver.FindElement(By.XPath("//div[@id='ctl00_ContentPlaceHolder_lstReports']//ul[@class='rlbList']"));
    //Assert.AreEqual(true, ReportType.Displayed);
        }
        [Test, Order(2)]
        public void reportsPandLCustomer()
        {
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//span[contains(text(),'Home')]")).Click();
            driver.FindElement(By.XPath("//span[@class='rpOut']//span[@class='rpText'][contains(text(),'Reports')]")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Profit and Loss by Customer')]")).Click();
     
            IWebElement AdvancedFiltering = driver.FindElement(By.XPath("//a[@id='ContentPlaceHolder_cmdAdvancedFiltering']"));
            Assert.AreEqual(true, AdvancedFiltering.Displayed);
        }
        [Test, Order(3)]
        public void reportsPandLPhone()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//span[contains(text(),'Home')]")).Click();
            driver.FindElement(By.XPath("//span[@class='rpOut']//span[@class='rpText'][contains(text(),'Reports')]")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Profit and Loss by Phone Number')]")).Click();
            IWebElement ResetBTN = driver.FindElement(By.XPath("//span[@id='ctl00_FunctionBarPlaceHolder_cmdReset']"));
            Assert.AreEqual(true, ResetBTN.Displayed);
        }
