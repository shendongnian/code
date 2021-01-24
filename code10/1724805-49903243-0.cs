    using System;
    
    public class Program
    {
    	private static void DisplayTimeInTimeZone(DateTime timeOfInterestUTC, string timezoneId)
    	{
    		Console.WriteLine($"UTC Time {timeOfInterestUTC} in {timezoneId} is {TimeZoneInfo.ConvertTime(timeOfInterestUTC, TimeZoneInfo.FindSystemTimeZoneById(timezoneId))}");
    	}
    
    	public static void Main()
    	{
    		/*
    		// In case you were wondering what Timezones are available
    		foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
    		{
    			Console.WriteLine(tz.Id);
    		}
    		*/
    		DateTime someArbitraryLocalTime = new DateTime(2018, 2, 15, 9, 30, 0);
    		DateTime someArbitraryTimeAsUTC = TimeZoneInfo.ConvertTimeToUtc(someArbitraryLocalTime, TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"));
    		Console.WriteLine($"US Eastern Standard Time {someArbitraryLocalTime} in UTC is {someArbitraryTimeAsUTC}");
    		DisplayTimeInTimeZone(someArbitraryTimeAsUTC, "GMT Standard Time");
    		DisplayTimeInTimeZone(someArbitraryTimeAsUTC, "Cen. Australia Standard Time");
    		DisplayTimeInTimeZone(someArbitraryTimeAsUTC, "Chatham Islands Standard Time");
    		DisplayTimeInTimeZone(someArbitraryTimeAsUTC, TimeZoneInfo.Local.Id);
    	}
    }
