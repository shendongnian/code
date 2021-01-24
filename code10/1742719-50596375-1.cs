    IList<IWebElement> banner = driver.FindElements(By.Id("bannerId"));
    IF ( list size is zero)
     { execute set of steps to set the banner }
     ELSE 
    {
     WebDriverWait wait2 = new WebDriverWait(driver, 
    TimeSpan.FromSeconds(40));
    wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("bannerId")));
    //Click on the first element of the list
    }
