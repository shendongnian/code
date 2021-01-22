    static void Main(string[] args)
    {
    	// http://msdn.microsoft.com/en-us/library/bb531208.aspx
    	MyMethod(new Dictionary<string,string>()
    	{
    		{"key1","value1"},
    		{"key2","value2"}
    	});
    }
    
    static void MyMethod(Dictionary<string, string> dictionary)
    {
    	foreach (string key in dictionary.Keys)
    	{
    		Console.WriteLine("{0} - {1}", key, dictionary[key]);
    	}
    }
