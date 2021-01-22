    public class DateTimeProvider
    {
    	protected static DateTime? DateTimeNow;
    	protected static DateTime? DateTimeUtcNow;
    
    	public DateTime Now
    	{
    		get
    		{
    			return DateTimeNow ?? System.DateTime.Now;
    		}
    	}
    
    	public DateTime UtcNow
    	{
    		get
    		{
    			return DateTimeUtcNow ?? System.DateTime.UtcNow;
    		}
    	}
    
    	public static DateTimeProvider DateTime
    	{
    		get
    		{
    			return new DateTimeProvider();
    		}
    	}
    
    	protected DateTimeProvider()
    	{       
    	}
    }
