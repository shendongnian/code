    IList<IWebElement> options= webDriver.FindElements(By.CssSelector("li[class*='select2-results__option']"));  
    foreach (IWebElement element in options){  
         if(element.GetText().Equals("2")){  
    
            element.Click();
        }
        }
