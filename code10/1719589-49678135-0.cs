    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		List<int> numberCount = new List<int>(){52, 52, 15, 32, 52, 7, 9};
    		bool showAllNumbers = true;
    		var query = (from x in numberCount.GroupBy(intGroup => intGroup).Select(intGroupInfo => new {intLabel = intGroupInfo.Key, Count = intGroupInfo.Count()}) where (x.Count > 1 || showAllNumbers) select x);
    		
    		foreach(var groupCount in query)
    		{
    			Console.WriteLine(String.Format("\"{0}\" occurs {1} times", groupCount.intLabel, groupCount.Count));
    		}
    		
    		
    	}
    }
