    void Main()
    {
    	var dictionary = new Dictionary<string, string>();
    	dictionary.AddIfNotPresent("key", "value");
    	Console.WriteLine($"{dictionary.First().Key} = {dictionary.First().Value}");
    
    	// Output: key = value
    }
    
    public static class DictionaryExtensions
    {
    	public static void AddIfNotPresent<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
    	{
    		if (!dict.ContainsKey(key))
    		{
    			dict.Add(key, value);
    		}
    	}
    }
