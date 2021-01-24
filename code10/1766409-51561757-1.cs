    public Boolean RetryingFindClick(By by){
    
    	try
    	{
    		var  wait = new WebDriverWait(BrowserHelper.WebDriver, TimeSpan.FromSeconds(20));
    		wait.Until(ExpectedConditions.ElementToBeClickable(by))    
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine(e);
    		return false;//Element is not found until the specified time
    	}
        return true;
    }
