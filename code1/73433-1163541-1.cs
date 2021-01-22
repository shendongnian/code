    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateRange.Generate(2009, 08, 01, 2009, 09, 31));
            Console.WriteLine(DateRange.Generate(2009, 08, 01, 2009, 08, 31));
            Console.WriteLine(DateRange.Generate(2009, 08, 01, 2009, 08, 09));
            Console.WriteLine(DateRange.Generate(2009, 01, 01, 2009, 03, 03));
            Console.WriteLine(DateRange.Generate(2009, 12, 06, 2010, 01, 08));
            // Same dates
            Console.WriteLine(DateRange.Generate(2009, 08, 01, 2009, 08, 01));
        }
    }
    static class DateRange
    {
        private static string[] Months = {
                                             "January", "February", "March", "April",
                                             "May", "June", "July", "August",
                                             "September", "October", "November", "December"
                                         };
        public static string Generate(
            int startYear, int startMonth, int startDay,
            int endYear, int endMonth, int endDay)
        {
            bool yearsSame = startYear == endYear;
            bool monthsSame = startMonth == endMonth;
            bool wholeMonths = (startDay == 1 && IsLastDay(endDay, endMonth));
            if ( monthsSame && yearsSame && startDay == endDay)
            {
                return string.Format("{0} {1}, {2}", startDay, Month(startMonth), startYear);
            }
            if (monthsSame)
            {
                if (yearsSame)
                {
                    return wholeMonths
                               ? string.Format("{0} {1}", Month(startMonth), endYear)
                               : string.Format("{0} {1} - {2}, {3}", Month(endMonth), startDay, endDay, endYear);
                }
                return wholeMonths
                           ? string.Format("{0}, {1} - {2}, {3}",
                                           Month(startMonth), startYear,
                                           Month(endMonth), endYear)
                           : string.Format("{0} {1}, {2} - {3} {4}, {5}",
                                           Month(startMonth), startDay, startYear,
                                           Month(endMonth), endDay, endYear);
            }
            if (yearsSame)
            {
                return wholeMonths
                           ? string.Format("{0} - {1}, {2}", Month(startMonth), Month(endMonth), endYear)
                           : string.Format("{0} {1} - {2} {3}, {4}",
                                           Month(startMonth), startDay,
                                           Month(endMonth), endDay,
                                           endYear);
            }
            return wholeMonths
                       ? string.Format("{0}, {1} - {2}, {3}",
                                       Month(startMonth), startYear,
                                       Month(endMonth), endYear)
                       : string.Format("{0} {1}, {2} - {3} {4}, {5}",
                                       Month(startMonth), startDay, startYear,
                                       Month(endMonth), endDay, endYear);
        }
        private static string Month(int month)
        {
            return Months[month - 1];
        }
        public static bool IsLastDay(int day, int month)
        {
            switch (month+1)
            {
                case 2:
                    // Not leap-year aware
                    return (day == 28 || day == 29);
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return (day == 31);
                case 4: case 6: case 9: case 11:
                    return (day == 30);
                default:
                    return false;
            }
        }
    }
