    using System;
    using System.Globalization;
    
    class Program
    {
        static void Main()
        {
    
            Console.WriteLine(DateTime.Now.ToMonthName());
            Console.WriteLine(DateTime.Now.ToShortMonthName());
            Console.Read();
        }
    }
    
    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }
    
        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
