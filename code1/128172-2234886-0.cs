    using System;
    
    public class Test
    {
        static void Main()
        {
            Console.WriteLine(SameDayLastYear(DateTime.Today));
            Console.WriteLine(SameDayLastYear(new DateTime(2010, 12, 31)));
        }
        
        static DateTime SameDayLastYear(DateTime original)
        {
            DateTime sameDate = original.AddYears(-1);
            int daysDiff = original.DayOfWeek - sameDate.DayOfWeek;
            return sameDate.AddDays(daysDiff);
        }
    }
