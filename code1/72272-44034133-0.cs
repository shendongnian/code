    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
    	public static void Main()
    	{
	    	Console.WriteLine("Hello World");
		    var listA = new List<int> { 1, 2, 3, 3, 2, 1 };
    		var listB = listA.Distinct();
    		foreach (var item in listB)
    		{
    			Console.WriteLine(item);
    		}
    	}
    }
    // output: 1,2,3
