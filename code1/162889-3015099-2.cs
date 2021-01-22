    class NestedType
    {
    	public MethodInvoker Stop = delegate() { };
    	public void DoWork()
    	{
    		while (true)
    		{
    			Stop();
    			// do work here
    		}
    	}
    }
    
    class ManagerType
    {
    	private bool shouldStop = false;
    	private void checkShouldStop()
    	{
    		if (this.shouldStop) { throw new OperationCanceledException(); }
    	}
    	public void ManageStuff()
    	{
    		NestedType nestedType = new NestedType();
    		nestedType.Stop = checkShouldStop;
    		nestedType.DoWork();
    	}
    }
