    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
    wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.XPath("(//table[contains(@class, 'table-main')])[1]//tbody//tr[normalize-space()]")));
    
    //Get the table.
    var table = _driver.FindElement(By.XPath("(//table[contains(@class, 'table-main')])[1]//tbody//tr[normalize-space()]"));
    
    Console.WriteLine(table.Text);
