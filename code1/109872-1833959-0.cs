    using System;
    using System.Globalization;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime d = DateTime.ParseExact("124510", "hhmmss", CultureInfo.InvariantCulture);
    
                Console.WriteLine("Total Seconds: " + d.TimeOfDay.TotalSeconds);
    
                Console.ReadLine();
            }
        }
    }
