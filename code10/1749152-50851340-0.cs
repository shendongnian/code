    public static class MyExtensions
    {
    	public static string RemoveFirstChar(this string str)
    	{
    	    return	string.IsNullOrEmpty(str) ? str : string.Join("", str.Skip(1));
    	}
    	
    }
