    using System;
					
    public class Program
    {
    	public static void Main()
    	{
    		string toParse = "1";
    		if (Decimal.TryParse(toParse, out var parsed)) {
    			Console.WriteLine("Parsed: " + parsed.ToString());
    		} else {
    			Console.WriteLine("Nope");
    		}
    	}
    }
