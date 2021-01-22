    const int TimedOutExceptionCode = -2147467259;
    public static bool IsMaxRequestExceededEexception(Exception e)
    {
    	// unhandeled errors = caught at global.ascx level
    	// http exception = caught at page level
    
    	Exception main;
    	var unhandeled = e as HttpUnhandledException;
    
    	if (unhandeled != null && unhandeled.ErrorCode == TimedOutExceptionCode)
    	{
    		main = unhandeled.InnerException;
    	}
    	else
    	{
    		main = e;
    	}
    
    
    	var http = main as HttpException;
    
    	if (http != null && http.ErrorCode == TimedOutExceptionCode)
    	{
    		// hack: no real method of identifing if the error is max request exceeded as 
    		// it is treated as a timeout exception
    		if (http.StackTrace.Contains("GetEntireRawContent"))
    		{
    			// MAX REQUEST HAS BEEN EXCEEDED
    			return true;
    		}
    	}
    
    
    	return false;
    }
