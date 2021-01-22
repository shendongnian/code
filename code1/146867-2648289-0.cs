    using System;
    using System.Globalization;
    
    class Example
    {
    	static void Main()
    	{
    		DateTime dateTime = DateTime.ParseExact("Thu Nov 30 19:00:00 EST 2006", 
    			"ddd MMM dd HH:mm:ss EST yyyy", 
    			CultureInfo.InvariantCulture);
    		Console.WriteLine(dateTime.ToString("MM/dd/yyyy"));
    	}
    }
