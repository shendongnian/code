    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.UtcNow;
            Console.WriteLine(string.Format("UTC time is {0}", time.ToShortTimeString()));
            
            TimeZone zone = TimeZone.CurrentTimeZone;
    
            //The following line depends on a call to TimeZone.GetUtcOffset for NET 1.0 and 1.1
            DateTime workingTime = zone.ToLocalTime(time);
            DisplayTime(workingTime, zone);
            IFormatProvider culture = new System.Globalization.CultureInfo("en-GB", true);
            workingTime = DateTime.Parse("22/2/2010 12:15:32");
    
            Console.WriteLine();
            Console.WriteLine(string.Format("Historical Date Time is : {0}",workingTime.ToString()));
            DisplayTime(workingTime, zone);
            Console.WriteLine("Press any key to close ...");
            Console.ReadLine();
        }
        static void DisplayTime(DateTime time, TimeZone zone)
        {
            Console.WriteLine(string.Format("Current time zone is {0}", zone.StandardName));
            Console.WriteLine(string.Format("Does this time include Daylight saving? - {0}", zone.IsDaylightSavingTime(time) ? "Yes" : "No"));
            if (zone.IsDaylightSavingTime(time))
            {
                Console.WriteLine(string.Format("So this time locally is {0} {1}", time.ToShortTimeString(), zone.DaylightName));
            }
            else
            {
                Console.WriteLine(string.Format("So this time locally is {0} {1}", time.ToShortTimeString(), zone.StandardName));
            }
            Console.WriteLine(string.Format("Time offset from UTC is {0} hours.", zone.GetUtcOffset(time)));
    
        }
    }
