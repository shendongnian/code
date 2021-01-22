    public class MockDateTimeProvider : DateTimeProvider
    {
    	public static void SetNow(DateTime now)
    	{
    		DateTimeNow = now;
    	}
    
    	public static void SetUtcNow(DateTime utc)
    	{
    		DateTimeUtcNow = utc;
    	}
    
    	public static void RestoreAsDefault()
    	{
    		DateTimeNow = null;
    		DateTimeUtcNow = null;
    	}
    }
