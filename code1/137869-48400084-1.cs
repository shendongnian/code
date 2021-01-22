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
