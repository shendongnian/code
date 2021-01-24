    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(<element xpath>)));
    Actions action = new Actions(Driver);
    action.MoveToElement(element).Perform();   
    //Waiting for the menu to be displayed    
    System.Threading.Thread.Sleep(4000);
