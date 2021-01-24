    IList<IWebElement> options= webDriver.FindElements(By.CssSelector(""));  
    foreach (IWebElement element in options){  
         if(element.GetText().Equals("2017")){  
    
            element.Click();
        }
        }
