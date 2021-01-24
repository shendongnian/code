    IList<IWebElement> options= webDriver.FindElements(By.CssSelector("span.select2-selection__rendered"));  
    foreach (IWebElement element in options){  
         if(element.GetText().Equals("2")){  
    
            element.Click();
        }
        }
