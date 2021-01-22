    private void ThreadLoop(object callback)
    {
    	while(true)
    	{
    		((Delegate) callback).DynamicInvoke(null);
    		Thread.Sleep(5000);
    	}
    }
