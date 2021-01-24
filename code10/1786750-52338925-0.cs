    public bool IsDataLoadingCompleted(){
    
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
        try
        {
            wait.Until(x => x.FindElement(By.CssSelector("[label='Form1_Field'],[label='Form1_Field']")).GetAttribute("value").Length > 1);
            return true;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }
