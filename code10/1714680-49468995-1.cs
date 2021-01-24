     //Wait for element to exist for up to 10 second before performing click operation
        driver.WaitAndClick(ExpectedConditions.ElementExists(By.XPath("xpath value")),TimeSpan.FromMilliseconds(10000));
            
     //Wait for element to be visible for up to 5 second before performing click operation   
         driver.WaitAndClick(ExpectedConditions.ElementIsVisible(By.Id("Id")),TimeSpan.FromMilliseconds(5000));
