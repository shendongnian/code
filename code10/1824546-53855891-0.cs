    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    class Edit<TWebDriver> : BaseTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private TWebDriver webDriver;
        
        public Edit(TWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        [Test]
        public void Test()
        {
            //test code
            if (this.webDriver.GetType() == typeof(InternetExplorerDriver))
            {
                Assert.Ignore("test not to be run in IE");
            }
        }
    }
