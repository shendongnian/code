    class Program
        {
            public static bool GameIsRun = true;
            public static IWebDriver driver = null;
            static void Main(string[] args)
            {
                CheckGame();
            }
    
            public static ChromeDriver GetDriver()
            {
                if(driver == null){
                     driver = new ChromeDriver();
                }
                return driver;
            }
    
            public static void CheckGame()
            {
                while (GameIsRun)
                {
                    GetInformation(GetDriver());
                }
            }
    
            static void GetInformation(ChromeDriver driver)
            {
                driver.Navigate().GoToUrl("myURL");
                do
                {
                   //loop for doing something on this page, I don't want to start my browser many times.  
                }
                while ();
            }
        }
