    using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var line = Console.ReadLine(); //for e.g : 20 10 10 200 (20 hours, 10 minutes, 10 seconds, 200 milliseconds)
    		DateTime time = DateTime.ParseExact(line, "HH mm ss fff", CultureInfo.InvariantCulture);		
    		Console.WriteLine(time);
    	}
    }
