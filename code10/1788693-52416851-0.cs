    List<IWebElement> rows = new List<IWebElement>
                             (table.FindElements(By.TagName("tr")));
    
    foreach (var row in rows) {
    
       ...
       // click back button on detail page
       backButton.click()
       // find the rows on table page again
       rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
    
    }
    // I'm not suer the foreach can remain the next iterate index even
    // I assign new value to the `rows`.  If foreach can't work in such case,
    // change to `for(var i=0;i<length;i++)` pattern.
