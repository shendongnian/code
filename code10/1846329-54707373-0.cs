    using System;
    
    namespace ConsoleApp26
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(ToTimeCode(null,null,"10",null));
                Console.WriteLine(ToTimeCode("1", "2", "3", "4"));
    
                Console.WriteLine(ToTimeCode2(null, null, "10", null));
                Console.WriteLine(ToTimeCode2("1", "2", "3", "4"));
    
                Console.ReadLine(); 
            }
    
            public static string ToTimeCode(string hours, string minutes, string seconds, string frames)
            {
                int.TryParse(hours, out int hoursInt);
                int.TryParse(minutes, out int minutesInt);
                int.TryParse(seconds, out int secondsInt);
                int.TryParse(frames, out int framesInt);
                var timespan = new TimeSpan(hoursInt, minutesInt, secondsInt, framesInt);
                return timespan.ToString("g");
            }
    
            public static string ToTimeCode2(string hours, string minutes, string seconds, string frames)
            {
                int.TryParse(hours, out int hoursInt);
                int.TryParse(minutes, out int minutesInt);
                int.TryParse(seconds, out int secondsInt);
                int.TryParse(frames, out int framesInt);
                var timespan = new TimeSpan(hoursInt, minutesInt, secondsInt, framesInt);
                return timespan.ToString(@"dd\.hh\:mm\:ss");
            }
        }
    }
