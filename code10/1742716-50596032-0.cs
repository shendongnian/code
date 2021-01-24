    try
    {
        var banner = FindElement(By.Id("bannerId"));
        IF ( checking if above element not present)
        { execute set of steps to set the banner }
        ELSE 
        {
           WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
           wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("bannerId")));
           banner.Click();
           Thread.Sleep(2000);
        }
    }
    catch(Exception ex)
    {
        //check what will be the return message from ex.Message
        //and from here you could add a logic what would be your next step.
    }
