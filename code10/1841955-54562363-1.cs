    public static IEnumerable<Row> GetRowsForTheFirstButton()
    {
    	var token = GridResultsSync.GetCurrentToken();
    
    	// retrieving data
    	...
    
    	if (GridResultsSync.IsTokenRelevant(token))
    		return result;
    	return null;
    }
    // exactly the same code for the second method
    public static IEnumerable<Row> GetRowsForTheSecondButton()
    {
    	var token = GridResultsSync.GetCurrentToken();
    
    	// retrieving data
    	...
    
    	if (GridResultsSync.IsTokenRelevant(token))
    		return result;
    		
    	return null;
    }
    
    ...
    class GridResultsSync
    {
    	static int _count = 0;
    	public static int GetCurrentToken()
    	{
    		var beforeCount = Interlocked.Increment(ref _count);
    		return beforeCount;
    	}
    	public static bool IsTokenRelevant(int token)
    	{
    		var currentCount = Interlocked.Increment(ref _count);
    		return currentCount - token  <=  2;
    	}
    }
