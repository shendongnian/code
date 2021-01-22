    public void ClickPrintButton()
    {
    	var iFrameDriver = Browser.Driver.SwitchToIFrame();
    	try
    	{
    		iFrameDriver.FindElement(By.Id("saveButton")).Click();
    	}
    	finally
    	{
    		Browser.Driver.SwitchOutOfIFrame();
    	}
    }
