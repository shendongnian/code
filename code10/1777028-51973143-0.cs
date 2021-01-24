    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	private static object mike = "mike"; // give the variable a value to hold
    	private static object gus = "gus"; // give the variable a value to hold
    	private static object julio = "julio"; // give the variable a value to hold
    	public static void Main()
    	{
    		object[] names = new object[3];
    		names[1] = mike;
    		names[0] = gus;
    		names[2] = julio;
    		WriteAnswer(" you're cool ", names);
    	}
    
    	static void WriteAnswer(string description, object[] result)
    	{
    			Console.WriteLine(description + string.Join(",", result));
    	}
    }
