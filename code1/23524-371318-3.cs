    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		List<String> names = new List<String> { "andrew", "nicole" };
    
    		names.ForEach(s => Console.WriteLine(s));
    
    		Console.Read();
    	}
    }
