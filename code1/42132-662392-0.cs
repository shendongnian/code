    using System;
    
    class Test
    {
        static void Main()
        {
            // Show the third Tuesday in 2009. Should be January 20th
            Console.WriteLine(YearWeekDayToDateTime(2009, DayOfWeek.Tuesday, 3));
        }
    
        static DateTime YearWeekDayToDateTime(int year, DayOfWeek day, int week)
        {
            DateTime startOfYear = new DateTime (year, 1, 1);
            
            // The +7 and %7 stuff is to avoid negative numbers etc.
            int daysToFirstCorrectDay = (((int)day - (int)startOfYear.DayOfWeek) + 7) % 7;
            
            return startOfYear.AddDays(7 * (week-1) + daysToFirstCorrectDay);
        }
    }
