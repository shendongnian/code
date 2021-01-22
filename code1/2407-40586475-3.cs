    void CallingMethod()
    {
    	try
    	{
    		throw new Exception( "TEST" );
    	}
    	catch( Exception ex )
    	{
    		throw new Exception( "RETHROW", ex );
    	}
    }
