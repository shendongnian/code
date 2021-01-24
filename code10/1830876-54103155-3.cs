    public sealed class Driver
    {
        [ThreadStatic]
        public static IWebDriver driver = null;
        
        public static IWebDriver Instance
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
        }
        public static void Testcleanup()
        {           
            driver.Quit();
            driver = null;
        }
    }
