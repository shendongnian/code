    IList<IWebElement> options= webDriver.FindElements(By.ID("select2-wa11-container"));
    for(WebElement element : options){
     if(element.GetText().Equals("2")){
        element.Click();
    }
    }
