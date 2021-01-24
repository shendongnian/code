    public void TestMethod1()
        {      
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            ChromeDriver webDriver = new ChromeDriver(option);
            try
            {
                webDriver.Navigate().GoToUrl("https://www.google.lk/");
                WebDriverWait wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 0, 30));
                IWebElement searchTextField= wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lst-ib")));
                searchTextField.SendKeys("Test");
                IWebElement searchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".lsb")));
                searchButton.Click();
                wait.Until(ExpectedConditions.TitleContains("Test"));
                IWebElement searchResultLink= wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='http://www.speedtest.net/']")));
                searchResultLink.Click();
            }
            finally { }
        }
