        private static int[,] weekdayOffsets = {
             // Su M  Tu W  Th F  Sa
                {0, 1, 2, 3, 4, 5, 5}, // Su
                {4, 0, 1, 2, 3, 4, 4}, // M 
                {3, 4, 0, 1, 2, 3, 3}, // Tu
                {2, 3, 4, 0, 1, 2, 2}, // W 
                {1, 2, 3, 4, 0, 1, 1}, // Th
                {0, 1, 2, 3, 4, 0, 0}, // F 
                {0, 1, 2, 3, 4, 5, 0}, // Sa
        };
        public static int GetWeekDayDiff(DateTime dtStart, DateTime dtEnd)
        {
            int daysDiff = (int)(dtEnd - dtStart).TotalDays;
            if (daysDiff >= 0)
            {
                return +5 * (daysDiff / 7) + weekdayOffsets[(int)dtStart.DayOfWeek, (int)dtEnd.DayOfWeek];
            }
            else
            {
                return -5 * (daysDiff / 7) + weekdayOffsets[6 - (int)dtStart.DayOfWeek, 6 - (int)dtEnd.DayOfWeek];
            }
        }
*I found that most other solutions on stack overflow were either slow (iterative) or overly complex and sadly almost all were just plain incorrect.*  Moral of the story is don't believe it unless *you've exhaustively unit tested it*.
Unit tests based on [NUnit Combinatorial](http://nunit.org/index.php?p=combinatorial&r=2.6.4) and [ShouldBe](https://github.com/tohagan/ShouldBe)
        /// <summary>
        /// Exclude start date, Include end date
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        private IEnumerable<DateTime> GetDateRange(DateTime dtStart, DateTime dtEnd)
        {
            Console.WriteLine("dtStart={0:yy-MMM-dd ddd}, dtEnd={1:yy-MMM-dd ddd}", dtStart, dtEnd);
            TimeSpan diff = dtEnd - dtStart;
            Console.WriteLine(diff);
            if (dtStart <= dtEnd)
            {
                for (DateTime dt = dtStart.AddDays(1); dt <= dtEnd; dt = dt.AddDays(1))
                {
                    Console.WriteLine("dt={0:yy-MMM-dd ddd}", dt);
                    yield return dt;
                }
            }
            else
            {
                for (DateTime dt = dtStart.AddDays(-1); dt >= dtEnd; dt = dt.AddDays(-1))
                {
                    Console.WriteLine("dt={0:yy-MMM-dd ddd}", dt);
                    yield return dt;
                }
            }
        }
        [Test, Combinatorial]
        public void TestAllDays(
            [Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 20, 30)]
            int startDay,
            [Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 20, 30)]
            int endDay,
            [Values(6, 9, 10)]
            int startMonth,
            [Values(4, 6, 11)]
            int endMonth)
        {
            DateTime dtStart = new DateTime(2016, startMonth, startDay);
            DateTime dtEnd   = new DateTime(2016, endMonth, endDay);
            int countDays = GetDateRange(dtStart, dtEnd)
                .Count(dt => dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday);
            Console.WriteLine("countDays={0}", countDays);
            DateExtensions.GetWeekDayDiff(dtStart, dtEnd).ShouldBe(countDays);
        }
