        namespace DateTimeExample
        {
            using System;
            public static class DateTimeExtension
            {
                public static DateTime GetMonday(this DateTime time)
                {
                    if (time.DayOfWeek != DayOfWeek.Monday)
                        return GetMonday(time.AddDays(-1)); //Recursive call
                    return time;
                }
            }
            internal class Program
            {
                private static void Main()
                {
                    Console.WriteLine(DateTime.Now.GetMonday());
                    Console.ReadLine();
                }
            }
        } 
