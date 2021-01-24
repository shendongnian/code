    static Configuration CreateFromDictionary(Dictionary<string, string> dict)
    {
        		try
    	{
    		return new Configuration
    		{
    			Name = dict.GetValue("Name"),
    			Url = dict.GetValue("Url"),
    			Password = dict.GetValue("Password")
    		}
    	}
    	catch (KeyNotFoundException ex)
    	{
    		throw new ArgumentException("Unable to construct a Configuration from the information given.", ex);
    	}
     }
    
    public static class ExtensionsUtil
    {
    	public static Tvalue GetValue<Tvalue, TKey>(this Dictionary<TKey, Tvalue> dict, TKey key)
    	{
    		Tvalue val = default(Tvalue);
    		if (dict.TryGetValue(key, out val))
    		{
    			return val;
    		}
    		else
    		{
    			throw new KeyNotFoundException($"'{key}' not found in the collection.");
    		}
    	}
    }
