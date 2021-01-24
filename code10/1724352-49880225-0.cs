    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main()
    	{
    		PopulateMxRecords(new List<string> { "Foo", "Bar" }).GetAwaiter().GetResult();
    	}
    
    	public static async Task PopulateMxRecords(List<string> nsRecords)
    	{
    		var tasks = nsRecords.Select(ns => Task.FromResult(ns)).ToList();
    		
    		while (tasks.Count() > 0)
    		{
    			var task = await Task.WhenAny(tasks);
    			tasks.Remove(task);
    
    			var mxRecords = await task;
    			Console.WriteLine(mxRecords);
    		}
    	}
    }
