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
