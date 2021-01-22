    public class Seasons
    {
    	public static string Spring { get; }
    	public static string Summer { get; }
    	public static string Fall { get; }
    	public static string Winter { get; }
    	
    	public static bool IsValid(string propertyName)
    	{
    		if (string.IsNullOrEmpty(propertyName))
    		{
    			return false;
    		}
    		
    		try
    		{	        
    			return typeof(Seasons).GetProperty(propertyName) != null;
    		}
    		catch
    		{
    			return false;
    		}		
    	}
    }
