            /// <summary>
        /// https://stackoverflow.com/questions/49924085/week-difference-between-2-dates-in-c-sharp#49924454
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public static int GetWeekDiff(DateTime dtStart, DateTime dtEnd, DayOfWeek startOfWeek = DayOfWeek.Monday) {
            //===============================================
            var diff = dtEnd.Subtract(dtStart);
            var weeks = (int)diff.Days / 7;
            // need to check if there's an extra week to count
            var remainingDays = diff.Days % 7;
            var cal = CultureInfo.InvariantCulture.Calendar;
            var d1WeekNo = cal.GetWeekOfYear(dtStart, CalendarWeekRule.FirstFullWeek, startOfWeek);
            var d1PlusRemainingWeekNo = cal.GetWeekOfYear(dtStart.AddDays(remainingDays), CalendarWeekRule.FirstFullWeek, startOfWeek);
            if (d1WeekNo != d1PlusRemainingWeekNo)
                weeks++;
            return weeks;
        }
