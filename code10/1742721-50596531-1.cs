    IList<IWebElement> elements = driver.FindElements(By.Id("bannerId")).ToList();
    if(elements.Count == 0)
    {
        do something
    }
    else 
    {
        //do something with the banner at elements[0]
        wait2.Until(ExpectedConditions.ElementToBeClickable(elements[0])).Click();
    }
