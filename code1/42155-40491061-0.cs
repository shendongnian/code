        /// <summary>
        /// Converts a date to a week number.
        /// ISO 8601 week 1 is the week that contains the first thursday that year.
        /// </summary>
        public static int ToIso8601Weeknumber(this DateTime date)
        {
            var thursday = date.AddDays(3 - date.DayOfWeek.DayOffset());
            return (thursday.DayOfYear - 1) / 7 + 1;
        }
        /// <summary>
        /// Converts a week number to a date.
        /// Note: Week 1 of a year may start in the previous year.
        /// ISO 8601 week 1 is the week that contains the first thursday that year.
        /// </summary>
        public static DateTime FromIso8601Weeknumber(int weekNumber, int? year = null, DayOfWeek day = DayOfWeek.Monday)
        {
            var dec28 = new DateTime((year ?? DateTime.Today.Year) - 1, 12, 28);
            var monday = dec28.AddDays(7 * weekNumber - dec28.DayOfWeek.DayOffset() + day.DayOffset());
            return monday;
        }
        /// <summary>
        /// Iso1864 weeks start on monday. This returns 0 for monday.
        /// </summary>
        private static int DayOffset(this DayOfWeek weekDay)
        {
            return ((int)weekDay + 6) % 7;
        }
