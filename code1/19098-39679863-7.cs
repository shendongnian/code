    using System;
    namespace JD
    {
        class Program
        {
            public static DateTime get_UTCNow()
            {
                DateTime UTCNow = DateTime.UtcNow;
                int year = UTCNow.Year;
                int month = UTCNow.Month;
                int day = UTCNow.Day;
                int hour = UTCNow.Hour;
                int min = UTCNow.Minute;
                int sec = UTCNow.Second;
                DateTime datetime = new DateTime(year, month, day, hour, min, sec);
                return datetime;
            }
            static void Main(string[] args)
            {
                DateTime datetime = get_UTCNow();
            
                string now = datetime.ToString();
                Console.WriteLine(now);
                string date = datetime.Date.ToString("d");
                string time_UTC = datetime.TimeOfDay.ToString();
                Console.WriteLine(date + " " + time_UTC);
                Console.ReadLine();
                string localTimeShort = datetime.ToString("t");
                Console.WriteLine(localTimeShort);
                string localTimeLong = datetime.ToString("T");
                Console.WriteLine(localTimeLong);
            
                Console.ReadLine();
            }
        }
    }
