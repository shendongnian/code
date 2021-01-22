    public static int TryGetInt(this IDictionary dict, string key)
    {
    	int val;
    	if (dict.Contains(key))
    	{
    		if (int.TryParse((string)dict[key], out val))
    			return val;
    	}
    
    	throw new Exception("Key not found.");
    }
