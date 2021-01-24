    try {
        WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        IWebElement element1 = wait1.Until(ExpectedConditions.ElementToBeClickable(By.TagName("result")));
    }catch {
        Console.WriteLine("No results");
    }
    if (driver.FindElements(By.TagName("result")).Count != 0)
