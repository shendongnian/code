    void Main()
    {
    	IList<string> list = new List<string>();
    	
    	if (list.FirstOrDefault() is string s1) 
    	{
    		Console.WriteLine("This won't print as the result is null, " +
                              "which doesn't match string");
    	}
    	
    	list.Add("Hi!");
    
    	if (list.FirstOrDefault() is string s2)
    	{
    		Console.WriteLine("This will print as the result is a string: " + s2);
    	}
    }
