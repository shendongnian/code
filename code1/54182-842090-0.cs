    using System;
    
    namespace TimeSpanFormat
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			TimeSpan dateDifference = new TimeSpan(0, 0, 6, 32, 445);
    			string formattedTimeSpan = string.Format("{0:D2} hrs, {1:D2} mins, {2:D2} secs", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);
    			Console.WriteLine(formattedTimeSpan);
    		}
    	}
    }
