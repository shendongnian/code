    namespace Tests
    {
        [TestFixture("*firefox")]
        [TestFixture("*iexplore")]
        public abstract class Test
        {
            private static string _browser;
            protected Test()
            {
            }
            protected Test(string browser)
            {
                SetBrowser(browser);
            }        
            public static void SetBrowser(string browser)
            {
                _browser = browser;
            }
        
            [SetUp]
            public virtual void Setup()
            {
	            Selenium = new DefaultSelenium(localhost, 5555, _browser, "http://www.google.com/");
                Selenium.Start();
            }
            [TearDown]
            public virtual void TearDown()
            {
	            Selenium.Stop();
            }
        }
    }
