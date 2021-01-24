    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var now = DateTime.Parse("00:30:00");
    		var ts = now.TimeOfDay; // ts is your timespan
    		Console.WriteLine(ts.TotalHours); // will print 0.5
    	}
    }
