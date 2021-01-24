       [TestCaseSource(nameof(Cases)), Parallelizable(ParallelScope.Children)]
            public void ItShouldSleep(TimeSpan t)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications");
                Driver = new ChromeDriver(@"C:\Users\slaouadi\source\repos\UnitTestProject1", options);
                string baseUrl = "https://www.google.com/";
                Driver.Navigate().GoToUrl(baseUrl);
                Driver.FindElement(By.Id("lst-ib")).SendKeys("IT WORKED FINE");
                
            }
