        /// <summary>
        /// Count Weekdays between two dates
        /// </summary>
        /// <param name="dtmStart">first date</param>
        /// <param name="dtmEnd">second date</param>
        /// <returns>weekdays between the two dates, including the start and end day</returns>
        internal static int getWeekdaysBetween(DateTime dtmStart, DateTime dtmEnd)
        {
            if (dtmStart > dtmEnd)
            {
                DateTime temp = dtmStart;
                dtmStart = dtmEnd;
                dtmEnd = temp;
            }
            /* Move border dates to the monday of the first full week and sunday of the last week */
            DateTime startMonday = dtmStart;
            int startDays = 1;
            while (startMonday.DayOfWeek != DayOfWeek.Monday)
            {
                if (startMonday.DayOfWeek != DayOfWeek.Saturday && startMonday.DayOfWeek != DayOfWeek.Sunday)
                {
                    startDays++;
                }
                startMonday = startMonday.AddDays(1);
            }
            DateTime endSunday = dtmEnd;
            int endDays = 0;
            while (endSunday.DayOfWeek != DayOfWeek.Sunday)
            {
                if (endSunday.DayOfWeek != DayOfWeek.Saturday && endSunday.DayOfWeek != DayOfWeek.Sunday)
                {
                    endDays++;
                }
                endSunday = endSunday.AddDays(1);
            }
            int weekDays;
            /* calculate weeks between full week border dates and fix the offset created by moving the border dates */
            weekDays = (Math.Max(0, (int)Math.Ceiling((endSunday - startMonday).TotalDays + 1)) / 7 * 5) + startDays - endDays;
            return weekDays;
        }
