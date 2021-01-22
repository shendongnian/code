C#
public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
{
    T key = default;
    foreach (KeyValuePair<T, W> pair in dict)
    {
        if (EqualityComparer<W>.Default.Equals(pair.Value, val))
        {
            key = pair.Key;
            break;
        }
    }
    return key;
}
Call it like follows:
    public static void Main()
    {
    	Dictionary<string, string> dict = new Dictionary<string, string>()
    	{
    		{"1", "one"},
    		{"2", "two"},
    		{"3", "three"}
    	};
    	
    	string key = KeyByValue(dict, "two"); 		
    	Console.WriteLine("Key: " + key);
    }
Works on .NET 2.0 and in other limited environments.
