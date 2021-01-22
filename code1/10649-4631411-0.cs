    void testExceptionHandling()
    {
    	try
    	{
    		throw new ArithmeticException("illegal expression");
    	}
    	catch (Exception ex)
    	{
    		throw;
    	}
    	finally
    	{
    		System.Diagnostics.Debug.WriteLine("finally called.");
    	}
    }
