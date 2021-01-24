    public static bool ContainsAny(this string source, params string[] containsArray)
    {
    	foreach (var s in containsArray)
    	{
    		if (source.Contains(s))
    		{
    			return true;
    		}
    	}
    
    	return false;
    }
