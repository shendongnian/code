    private static object _syncLock = new object();
    
    public void RunCriticalCode()
    {
    	lock (_syncLock)
    	{
    		// critical code
    	}
    }
