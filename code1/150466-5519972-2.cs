    private const string ProductKey = "ProductViewStateKey";
    public string Product
    {
    	get
    	{
    		if (ViewState[ProductKey] == null)
    		{
    			  // do whatever you want here in case it's null 
                  // throw an error, return string.empty or whatever
    		}
    		return ViewState[ProductKey].ToString();
    	}
    
    	set
    	{
    		ViewState[ProductKey] = value;
    	}
    }
