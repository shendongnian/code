    public bool AssertCookieButtonDisplayed()
    {
    	bool isDisplayed = false;
    	try {
    		isDisplayed = CookieButton.Displayed;
    	}
    	catch{}
         
        return isDisplayed;
    }
