    // template method
    void Execute(Action test)
    {
    	try
    	{
    		test();
    	}
    	catch (Exception e)
    	{
    		// handle exception here
    		throw;
    	}
    }
    
    [Test]
    public void Test()
    {
    	Execute(() =>
    		{
    			// your test here
    		});
    }
