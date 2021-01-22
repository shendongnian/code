        /// <summary>
        /// Converts a date to a week number.
        /// ISO 8601 week 1 is the week that contains the first Thursday that year.
        /// </summary>
        public static int ToIso8601Weeknumber(this DateTime date)
        {
            var thursday = date.AddDays(3 - date.DayOfWeek.DayOffset());
            return (thursday.DayOfYear - 1) / 7 + 1;
        }
        /// <summary>
        /// Converts a week number to a date.
        /// Note: Week 1 of a year may start in the previous year.
        /// ISO 8601 week 1 is the week that contains the first Thursday that year, so
        /// if December 28 is a Monday, December 31 is a Thursday,
        /// and week 1 starts January 4.
        /// If December 28 is a later day in the week, week 1 starts earlier.
        /// If December 28 is a Sunday, it is in the same week as Thursday January 1.
        /// </summary>
        public static DateTime FromIso8601Weeknumber(int weekNumber, int? year = null, DayOfWeek day = DayOfWeek.Monday)
        {
            var dec28 = new DateTime((year ?? DateTime.Today.Year) - 1, 12, 28);
            var monday = dec28.AddDays(7 * weekNumber - dec28.DayOfWeek.DayOffset());
            return monday.AddDays(day.DayOffset());
        }
        /// <summary>
        /// Iso8601 weeks start on Monday. This returns 0 for Monday.
        /// </summary>
        private static int DayOffset(this DayOfWeek weekDay)
        {
            return ((int)weekDay + 6) % 7;
        }
