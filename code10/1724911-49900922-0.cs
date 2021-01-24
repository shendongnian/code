    using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var n = 11822252.79m;
    		
    		Console.WriteLine( n.ToString("#,###.00", CultureInfo.InvariantCulture));
    		Console.ReadLine();	
    	}
    }
