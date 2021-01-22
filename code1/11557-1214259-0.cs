    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		List<String> names = new List<String>
    		{
    			"Nicole Hare",
    			"Michael Hare",
    			"Joe Hare",
    			"Sammy Hare",
    			"George Washington",
    		};
             
            // Here I am passing "inMyFamily" to the "Where" extension method
            // on my List<String>.  The C# compiler automatically creates 
            // a delegate instance for me.
    		IEnumerable<String> myFamily = names.Where(inMyFamily);
    
    		foreach (String name in myFamily)
    			Console.WriteLine(name);
    	}
    
    	static Boolean inMyFamily(String name)
    	{
    		return name.EndsWith("Hare");
    	}
    }
