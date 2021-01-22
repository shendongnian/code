        #region FirstWeekOfYear
        /// <summary>
        /// Gets the first week of the year.
        /// </summary>
        /// <param name="year">The year to retrieve the first week of.</param>
        /// <returns>A <see cref="DateTime"/>representing the start of the first
        /// week of the year.</returns>
        /// <remarks>
        /// Week 01 of a year is per definition the first week that has the Thursday 
        /// in this year, which is equivalent to the week that contains the fourth
        /// day of January. In other words, the first week of a new year is the week
        /// that has the majority of its days in the new year. Week 01 might also 
        /// contain days from the previous year and the week before week 01 of a year
        /// is the last week (52 or 53) of the previous year even if it contains days 
        /// from the new year.
        /// A week starts with Monday (day 1) and ends with Sunday (day 7). 
        /// </remarks>
        private static DateTime FirstWeekOfYear(int year)
        {
            int dayNumber;
            // Get the date that represents the fourth day of January for the given year.
            DateTime date = new DateTime(year, 1, 4, 0, 0, 0, DateTimeKind.Utc);
            // A week starts with Monday (day 1) and ends with Sunday (day 7).
            // Since DayOfWeek.Sunday = 0, translate it to 7. All of the other values
            // are correct since DayOfWeek.Monday = 1.
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                dayNumber = 7;
            }
            else
            {
                dayNumber = (int)date.DayOfWeek;
            }
            // Since the week starts with Monday, figure out what day that 
            // Monday falls on.
            return date.AddDays(1 - dayNumber);
        }
        #endregion
        #region GetIsoDate
        /// <summary>
        /// Gets the ISO date for the specified <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> for which the ISO date
        /// should be calculated.</param>
        /// <returns>An <see cref="Int32"/> representing the ISO date.</returns>
        private static int GetIsoDate(DateTime date)
        {
            DateTime firstWeek;
            int year = date.Year;
            // If we are near the end of the year, then we need to calculate
            // what next year's first week should be.
            if (date >= new DateTime(year, 12, 29))
            {
                if (date == DateTime.MaxValue)
                {
                    firstWeek = FirstWeekOfYear(year);
                }
                else
                {
                    firstWeek = FirstWeekOfYear(year + 1);
                }
                // If the current date is less than next years first week, then
                // we are still in the last month of the current year; otherwise
                // change to next year.
                if (date < firstWeek)
                {
                    firstWeek = FirstWeekOfYear(year);
                }
                else
                {
                    year++;
                }
            }
            else
            {
                // We aren't near the end of the year, so make sure
                // we're not near the beginning.
                firstWeek = FirstWeekOfYear(year);
                // If the current date is less than the current years
                // first week, then we are in the last month of the
                // previous year.
                if (date < firstWeek)
                {
                    if (date == DateTime.MinValue)
                    {
                        firstWeek = FirstWeekOfYear(year);
                    }
                    else
                    {
                        firstWeek = FirstWeekOfYear(--year);
                    }
                }
            }
            // return the ISO date as a numeric value, so it makes it
            // easier to get the year and the week.
            return (year * 100) + ((date - firstWeek).Days / 7 + 1);
        }
        #endregion
        #region Week
        /// <summary>
        /// Gets the week component of the date represented by this instance.
        /// </summary>
        /// <value>The week, between 1 and 53.</value>
        public int Week
        {
            get
            {
                return this.isoDate % 100;
            }
        }
        #endregion
        #region Year
        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        /// <value>The year, between 1 and 9999.</value>
        public int Year
        {
            get
            {
                return this.isoDate / 100;
            }
        }
        #endregion
