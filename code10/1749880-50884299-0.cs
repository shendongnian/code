    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		
    		var list = new List<StatsSnapshot>();
    		list.Add(new StatsSnapshot());
    		list.Add(new StatsSnapshot());
    		
            var result = ProcessPeriodicities(list)
                .Where(i => i != null)
                .ToArray();
    	}
    	
    	
    	private static IEnumerable<StatsSnapshot> ProcessPeriodicities(ICollection<StatsSnapshot> newStats)
        {
            foreach (var s in newStats)
            {
                yield return ProcessPeriodicity(s, 1);
                yield return ProcessPeriodicity(s, 2);
                yield return ProcessPeriodicity(s, 3);
                yield return ProcessPeriodicity(s, 4);
                yield return ProcessPeriodicity(s, 5);
    			
    			Console.WriteLine("Finished a foreach loop");
            }
    		
    		
        }
    	
    	private static StatsSnapshot ProcessPeriodicity(StatsSnapshot s, int i)
    	{
    		Console.WriteLine(i);
    		
    		return s;
    	}
    }
    
    public class StatsSnapshot
    {
    	
    }
