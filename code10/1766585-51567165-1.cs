    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
            // I would suggest using SortedDictionary instead of OrderedDictionary because you wont need to cast the value later.
    		var spellResults = new SortedDictionary<string, int[]>{{"Test", new int[]{5, 7}}};
            // nums will be of type int[] because we defined type when instantiating SortedDictionary
            var nums = spellResults["Test"];
            // loop through the array
            foreach (int num in nums)
            {
        		Console.WriteLine(num.ToString());
        	}
        }
    }
