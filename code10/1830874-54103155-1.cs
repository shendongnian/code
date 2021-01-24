    [TestClass]
    public class TestBase
    {
        [ThreadStatic]
        public static IWebDriver driver = null;
        
        [TestInitialize]
        public void TestInitialize()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
        }
        [TestCleanup]
        public void Testcleanup()
        {           
            driver.Quit();
            driver = null;
        }
    }
