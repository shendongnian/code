        /// <summary>
        /// Calculate the differences in years.
        /// This will round up to catch partial months.
        /// </summary>
        /// <param name="lValue"></param>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static int YearDifference(DateTime lValue, DateTime rValue)
        {
            return lValue.Year - rValue.Year +
                   (lValue.Month > rValue.Month // Partial month, same year
                       ? 1
                       : lValue.Day > rValue.Day // Partial month, same year and month
                       ? 1 : 0);
        }
