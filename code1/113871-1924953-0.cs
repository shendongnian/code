    static void Main(string[] args) {
    	try {
    		List<string> stuff = new List<string>();
    		int newStuff = 0;
    
    		for (int i = 0; i < 10; i++)
    			stuff.Add(".");
    
    		Console.WriteLine("Doing ForEach()");
    
    		stuff.ForEach(delegate(string s) {
    			Console.Write(s);
    
    			if (++newStuff < 10)
    				stuff.Add("+"); // This will work fine and you will continue to loop though it.
    		});
    
    		Console.WriteLine();
    		Console.WriteLine("Doing foreach() { }");
    
    		newStuff = 0;
    
    		foreach (string s in stuff) {
    			Console.Write(s);
    
    			if (++newStuff < 10)
    				stuff.Add("*"); // This will cause an exception.
    		}
    
    		Console.WriteLine();
    	}
    	catch {
    		Console.WriteLine();
    		Console.WriteLine("Error!");
    	}
    	
    	Console.ReadLine();
    }
