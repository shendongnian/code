    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		Action<String> print = new Action<String>(Program.Print);
    
    		List<String> names = new List<String> { "andrew", "nicole" };
    
    		names.ForEach(print);
    
    		Console.Read();
    	}
    
    	static void Print(String s)
    	{
    		Console.WriteLine(s);
    	}
    }
