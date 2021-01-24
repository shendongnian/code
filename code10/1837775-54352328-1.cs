    IList<IWebElement> boxList = _driver.FindElements(By.CssSelector("select#ListBox option"));
    bool textExists = false;
    
    foreach(var option in boxList)
    {
        if(option.Text.Contains("TEST"))
        {
            textExists = true;
            break;
        }
    }
    
    if(!textExists)
    {
        _driver.FindElement(By.Id("AddButton")).Click();
        var newRecordInfo = table.CreateSet<FeatureInfo>();
        
        foreach (var recordData in newRecordInfo)
        {
             _driver.FindElement(By.Id("DesTextBox")).SendKeys(recordData.Test_discription);
             _driver.FindElement(By.Id("ScoreTextBox")).SendKeys(recordData.Test_score);
    
             new SelectElement(_driver.FindElement(By.Id("TypeDropDown"))).SelectByValue("1");
             _driver.FindElement(By.Id("SaveButton")).Click();
        }
    }
