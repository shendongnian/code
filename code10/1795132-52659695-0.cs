    private bool isSearchRunning = false;
    private void SearchButtonCommandImpl()
    {
    	if (isSearchRunning)
    	{
    		return;
    	}
    	try
    	{
    		isSearchRunning = true;
    		//Do stuff
    	}
    	finally
    	{
    		isSearchRunning = false;
    	}
    }
