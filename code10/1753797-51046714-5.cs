    IList<IWebElement> options= webDriver.FindElements(By.CssSelector("select[id='year']>option"));  
    foreach (IWebElement element in options){  
         if(element.GetText().Equals("2017")){  
    
            element.Click();
        }
        }
