        /// <summary>
        /// Calculate the difference in months.
        /// This will round up to count partial months.
        /// </summary>
        /// <param name="lValue"></param>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            var yearDifferenceInMonths = (lValue.Year - rValue.Year) * 12;
            var monthDifference = lValue.Month - rValue.Month;
            return yearDifferenceInMonths + monthDifference + 
                (lValue.Day > rValue.Day
                    ? 1 : 0); // If end day is greater than start day, add 1 to round up the partial month
        }
