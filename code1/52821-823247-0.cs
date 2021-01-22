    public void MyDLLFunction()
    {
    	try
    	{
    		//some interesting code that may
    		//cause an error here
    	}
    	catch (Exception ex)
    	{
    		// do some logging, handle the error etc.
    		// if you can't handle the error then throw to
    		// the calling code
    		throw;
    		//not throw ex; - that resets the call stack
    	}
    }
