    using System;
    using System.Globalization;
    
    public class Program
    {
    	public static void Main()
    	{
    		string thaiBudistDate = "12/7/2561";
    		
    		// US format
    		CultureInfo provider = CultureInfo.GetCultureInfo("en-US");
    		DateTime date = DateTime.Parse(thaiBudistDate, provider);
    		Console.WriteLine("Original string: '" + provider + "' in 'en-US' => Day: " + date.Day + " Month: " + date.Month + " Year: " + date.Year );
    				
    		// Thai Culture
    		provider = CultureInfo.GetCultureInfo("th-TH");
    		date = DateTime.Parse(thaiBudistDate, provider);
    		Console.WriteLine("Original string: '" + provider + "' in 'th-TH' => Day: " + date.Day + " Month: " + date.Month + " Year: " + date.Year );
    		
    		// Thai Culture format! M/d/yyyy
    		provider = CultureInfo.GetCultureInfo("th-TH");
    		var format = "M/d/yyyy";
    		date = DateTime.ParseExact(thaiBudistDate, format, provider);
    		Console.WriteLine("Original string: '" + provider + "' in 'th-TH' format specified 'M/d/yyyy' => Day: " + date.Day + " Month: " + date.Month + " Year: " + date.Year );
    		
    		// Thai Culture format d/M/yyyy 
    		provider = CultureInfo.GetCultureInfo("th-TH");
    		format = "d/M/yyyy";
    		date = DateTime.ParseExact(thaiBudistDate, format, provider);
    		Console.WriteLine("Original string: '" + provider + "' in 'th-TH' format specified 'd/M/yyyy' => Day: " + date.Day + " Month: " + date.Month + " Year: " + date.Year );
    						  
    		// Using Gregorian time
    		string usaDate = "12/7/2018";
    		// US Culture
    		provider = CultureInfo.GetCultureInfo("en-US");
    		date = DateTime.Parse(usaDate, provider);
    		Console.WriteLine("Original string: '" + usaDate + "' in 'en-Us' => Day: " + date.Day + " Month: " + date.Month + " Year: " + date.Year );
    		
    		
    		// You got the point, dones't matter what provider you use! Hope this will help you undestand how wondows Culture works
    		usaDate = "12/7/2018";
    		// Thai Culture
    		provider = CultureInfo.GetCultureInfo("th-TH");
    		date = DateTime.Parse(usaDate, provider);
    		Console.WriteLine("Original string: '" + usaDate + "' in 'th-TH' => Day: " + date.Day + " Month: " + date.Month + " Year: " + date.Year );
    		
    	}
    }
