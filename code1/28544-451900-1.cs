    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		var dict = new Dictionary<String, Double>();
    		dict.Add("four", 4);
    		dict.Add("three", 3);
    		dict.Add("two", 2);
    		dict.Add("five", 5);
    		dict.Add("one", 1);
    
    		var sortedDict = new SortedDictionary<Double, String>(dict.AsInverted());
    	}
    }
