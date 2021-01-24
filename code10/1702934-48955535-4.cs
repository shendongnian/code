    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var result = Enumerable
    			.Range(1,10)
    			.Select((i) => new 
    			{
    				Value = i,
    				IsEven = i % 2 == 0 ? "Even" : "Odd"
    			});
    		
    		foreach (var r in result)
    		{
    			Console.WriteLine(r.Value + " is " + r.IsEven);
    		}
    	}
    }
