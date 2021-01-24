    public void searchAndClick(string name) {
    foreach (IWebElement row in tableRow){
      if (row.Text.Equals(name)){  
       driver.FindElement(By.Xpath("//td[text()='"+name+"']/following-sibling::td[contains(@class,'text-center')]/button")).Click();
    }
    }  
    }
 
    
     
