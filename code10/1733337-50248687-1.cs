    ChromeOptions option = new ChromeOptions();
    option.AddArgument("--headless");
    ChromeDriver wd = new ChromeDriver(option);
    wd.Navigate().GoToUrl("https://www.google.co.in/");
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));  
    wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("q")));  
    wd.FindElement(By.Name("q")).SendKeys("Test"+Keys.RETURN);  
    wait.Until(ExpectedConditions.VisibilityOfElementLocated(By.CssSelector("a[href='http://www.speedtest.net/']")));  
    driver.FindElement(By.CssSelector("a[href='http://www.speedtest.net/']")).Click();  
