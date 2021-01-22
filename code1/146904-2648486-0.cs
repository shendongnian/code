    using System;
    using System.Linq;
    
    class Example
    {
    	static void Main()
    	{
    		var names = new[] { "Andrew", "Nicole", "Michael",
    			"Joe", "Sammy", "Joshua" };
    
    		var shortNames = from n in names
    			   where n.Length == 6
    			   select n;
    		var first = names.First();
    	}
    }
