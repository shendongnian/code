    namespace Tests
    {
    [TestFixture("*firefox")]
    [TestFixture("*iexplore")]
    public abstract class Test
    {
        private static string browser;
        protected Test()
        {
        }
        protected Test(string browser)
        {
            SetBrowser(browser);
        }        
        public static void SetBrowser(string newBrowser)
        {
            browser = newBrowser;
        }
        
        [SetUp]
        public virtual void Setup()
        {
	    Selenium = new DefaultSelenium(localhost, 5555, browser, "http://www.google.com/");
            Selenium.Start();
        }
        [TearDown]
        public virtual void TearDown()
        {
	    Selenium.Stop();
        }
    }
    }
