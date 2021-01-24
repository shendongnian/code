    List<WebElement> rows = new List<WebElement>(table.FindElements(By.TagName("tr")));
    var rowsCount = rows.Count;
    for(int i=0; i<rowsCount; i++)
    {
        var row = rows[i];
        // do what you need to do on this row e.g. row.Click();
        row.Click();
        
        // click back and wait 
        back.Click();
        System.Threading.Thread.Sleep(10000);
    
        rows = new List<WebElement>(table.FindElements(By.TagName("tr")));
    }
