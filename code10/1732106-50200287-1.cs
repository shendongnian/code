    using System;
    
    public class Program
    {
        static void Main()
        {
            var dates = new[]
            {
                new DateTime(2000, 1, 1),
                new DateTime(2001, 1, 1),
                new DateTime(2000, 3, 1),
                new DateTime(2001, 3, 1),
                new DateTime(2000, 4, 1),
                new DateTime(2001, 4, 1),
                new DateTime(2000, 5, 1),
                new DateTime(2001, 5, 1),
                new DateTime(2000, 12, 31),
                new DateTime(2001, 12, 31),
            };
            foreach (var date in dates)
            {
                int dayOfQuarter = DayOfQuarter(date);
                Console.WriteLine($"{date:yyyy-MM-dd}: {dayOfQuarter}");
            }
        }
        
        public static int DayOfQuarter(DateTime dt)
        {
            int zeroBasedQuarter = (dt.Month - 1) / 3;
            DateTime startOfQuarter = new DateTime(dt.Year, zeroBasedQuarter * 3 + 1, 1);
            return dt.DayOfYear - startOfQuarter.DayOfYear + 1;
        }
    }
