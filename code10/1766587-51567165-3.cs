    using System;
    using System.Collections.Specialized;
    
    public class Program
    {
    	public static void Main()
    	{
    		var spellResults = new OrderedDictionary()
    		{{"Test", new int[]{5, 7}}};
    		var nums = spellResults["Test"] as int[];
    		if (nums != null)
    		{
    			foreach (int num in nums)
    			{
    				Console.WriteLine(num.ToString());
    			}
    		}
    	}
    }
