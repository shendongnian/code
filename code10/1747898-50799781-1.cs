    static ChromeDriver driver;
    public static void Order_go(string url, string name) 
    {
         if (driver == null) { driver = new ChromeDriver(); }
    
         driver.Url = (url);  
         IWebElement b_login1 = driver.FindElement(By.Id("login"));
         b_login1.SendKeys("aa");
         IWebElement b_pass1 = driver.FindElement(By.Name("managerPw"));
         b_pass1.SendKeys("123");
         //Execute each time when it is called
    }
