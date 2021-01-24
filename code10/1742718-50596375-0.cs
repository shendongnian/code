     try   
    {
    var banner = FindElement(By.Id("bannerId"));
    WebDriverWait wait2 = new WebDriverWait(driver, 
    TimeSpan.FromSeconds(40));
    wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("bannerId")));
    banner.Click();
    Thread.Sleep(2000);
    }
     catch (NoSuchElementException ex)
    {
      //Give the appropriate message
    }
