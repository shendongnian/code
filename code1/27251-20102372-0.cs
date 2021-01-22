    public static void LogException(Exception exc, string source)
    {
    	try
    	{
    		// Logic for logging exceptions
    	}
    	catch(Exception ex)
    	{
    		//If logging fails  for some reason 
    		//then we still log it using reflection
    		LogException(ex, "Error while logging an exception");
    	}
    }
