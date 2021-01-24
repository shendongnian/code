    using System;
    using System.Globalization;
    
    namespace ConsoleApp1
    {
        public class Program
        { 
            public static void Main(String[] args)
            {
                var date = DateTime.Now;
                var str = date.ToPersianDate();
                Console.WriteLine(str);
                Console.Read();
            }
        }
    
        public static class Extender
        {
            public static string ToPersianDate(this DateTime t)
            {
                var pc = new PersianCalendar();
                return $"{pc.GetYear(t)}/{pc.GetMonth(t)}/{pc.GetDayOfMonth(t)}";
            }
        }
    }
