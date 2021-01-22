    static class DictionaryExtensions
    {
    	public static TValue GetValueOrDefault<TKey,TValue>(this IDictionary<TKey,TValue> dict, TKey key)
    	{
    		TValue value;
    		if(dict.TryGetValue(key, out value))
    			return value;
    		return default(TValue);
    	}
    }
    //Example usage
    paramList.GetValueOrDefault("mykey") ?? "mykey didn't exist";
