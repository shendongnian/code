    using System;
	using System.Globalization;				
	
    public class Program
    {
	    public static void Main()
	    {
		    var cdnTime = TimeSpan.Parse("23:12", CultureInfo.InvariantCulture);
		    var nextTime = TimeSpan.Parse("01.00:03", CultureInfo.InvariantCulture);
		
		    Console.WriteLine(cdnTime.TotalMinutes);
		    Console.WriteLine(nextTime.TotalMinutes);
		    Console.WriteLine(cdnTime.CompareTo(nextTime));
		    Console.WriteLine(cdnTime < nextTime);
	}
