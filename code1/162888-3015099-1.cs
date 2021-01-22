    class NestedType
    {
    	// note: the argument of Predicate<T> is not used, 
        //    you could create a new delegate type that accepts no arguments 
        //    and returns T
    	public Predicate<bool> ShouldStop = delegate() { return false; };
    	public void DoWork()
    	{
    		while (!this.ShouldStop(false))
    		{
    			// do work here
    		}
    	}
    }
    
    class ManagerType
    {
    	private bool shouldStop = false;
    	private bool checkShouldStop(bool ignored)
    	{
    		return shouldStop;
    	}
    	public void ManageStuff()
    	{
    		NestedType nestedType = new NestedType();
    		nestedType.ShouldStop = checkShouldStop;
    		nestedType.DoWork();
    	}
    }
