    /// <summary>
    /// Helper/extension class for manipulating date and time values.
    /// </summary>
    public static class DateTimeExtensions
	{
        /// <summary>
        /// Calculates the absolute year difference between two dates.
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns>A whole number representing the number of full years between the specified dates.</returns>
        public static int Years(DateTime dt1,DateTime dt2)
		{
			return Months(dt1,dt2)/12;
			//if (dt2<dt1)
			//{
			//    DateTime dt0=dt1;
			//    dt1=dt2;
			//    dt2=dt0;
			//}
			//int diff=dt2.Year-dt1.Year;
			//int m1=dt1.Month;
			//int m2=dt2.Month;
			//if (m2>m1) return diff;
			//if (m2==m1 && dt2.Day>=dt1.Day) return diff;
			//return (diff-1);
		}
        /// <summary>
        /// Calculates the absolute year difference between two dates.
        /// Alternative, stand-alone version (without other DateTimeUtil dependency nesting required)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int Years2(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
        /// <summary>
        /// Calculates the absolute month difference between two dates.
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns>A whole number representing the number of full months between the specified dates.</returns>
        public static int Months(DateTime dt1,DateTime dt2)
		{
			if (dt2<dt1)
			{
				DateTime dt0=dt1;
				dt1=dt2;
				dt2=dt0;
			}
			dt2=dt2.AddDays(-(dt1.Day-1));
			return (dt2.Year-dt1.Year)*12+(dt2.Month-dt1.Month);
		}
		/// <summary>
		/// Returns the higher of the two date time values.
		/// </summary>
		/// <param name="dt1">The first of the two <c>DateTime</c> values to compare.</param>
		/// <param name="dt2">The second of the two <c>DateTime</c> values to compare.</param>
		/// <returns><c>dt1</c> or <c>dt2</c>, whichever is higher.</returns>
		public static DateTime Max(DateTime dt1,DateTime dt2)
		{
			return (dt2>dt1?dt2:dt1);
		}
		/// <summary>
		/// Returns the lower of the two date time values.
		/// </summary>
		/// <param name="dt1">The first of the two <c>DateTime</c> values to compare.</param>
		/// <param name="dt2">The second of the two <c>DateTime</c> values to compare.</param>
		/// <returns><c>dt1</c> or <c>dt2</c>, whichever is lower.</returns>
		public static DateTime Min(DateTime dt1,DateTime dt2)
		{
			return (dt2<dt1?dt2:dt1);
		}
        /// <summary>
        /// Adds the given number of business days to the <see cref="DateTime"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <param name="holidays">An optional list of holiday (non-business) days to consider.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime AddBusinessDays(
            this DateTime current, 
            int days, 
            IEnumerable<DateTime> holidays = null)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (current.DayOfWeek == DayOfWeek.Saturday
                    || current.DayOfWeek == DayOfWeek.Sunday
                    || (holidays != null && holidays.Contains(current.Date))
                    );
            }
            return current;
        }
        /// <summary>
        /// Subtracts the given number of business days to the <see cref="DateTime"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be subtracted.</param>
        /// <param name="holidays">An optional list of holiday (non-business) days to consider.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static DateTime SubtractBusinessDays(
            this DateTime current, 
            int days,
            IEnumerable<DateTime> holidays)
        {
            return AddBusinessDays(current, -days, holidays);
        }
        /// <summary>
        /// Retrieves the number of business days from two dates
        /// </summary>
        /// <param name="startDate">The inclusive start date</param>
        /// <param name="endDate">The inclusive end date</param>
        /// <param name="holidays">An optional list of holiday (non-business) days to consider.</param>
        /// <returns></returns>
        public static int GetBusinessDays(
            this DateTime startDate, 
            DateTime endDate,
            IEnumerable<DateTime> holidays)
        {
            if (startDate > endDate)
                throw new NotSupportedException("ERROR: [startDate] cannot be greater than [endDate].");
 
            int cnt = 0;
            for (var current = startDate; current < endDate; current = current.AddDays(1))
            {
                if (current.DayOfWeek == DayOfWeek.Saturday
                    || current.DayOfWeek == DayOfWeek.Sunday
                    || (holidays != null && holidays.Contains(current.Date))
                    )
                {
                    // skip holiday
                }
                else cnt++;
            }
            return cnt;
        }
        /// <summary>
        /// Calculate Easter Sunday for any given year.
        /// src.: https://stackoverflow.com/a/2510411/1233379
        /// </summary>
        /// <param name="year">The year to calcolate Easter against.</param>
        /// <returns>a DateTime object containing the Easter month and day for the given year</returns>
        public static DateTime GetEasterSunday(int year)
        {
            int day = 0;
            int month = 0;
            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));
            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;
            if (day > 31)
            {
                month++;
                day -= 31;
            }
            return new DateTime(year, month, day);
        }
        /// <summary>
        /// Retrieve holidays for given years
        /// </summary>
        /// <param name="years">an array of years to retrieve the holidays</param>
        /// <param name="countryCode">a country two letter ISO (ex.: "IT") to add the holidays specific for that country</param>
        /// <param name="cityName">a city name to add the holidays specific for that city</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> GetHolidays(IEnumerable<int> years, string countryCode = null, string cityName = null)
        {
            var lst = new List<DateTime>();
            foreach (var year in years.Distinct())
            {
                lst.AddRange(new[] {
                    new DateTime(year, 1, 1),       // 1 gennaio (capodanno)
                    new DateTime(year, 1, 6),       // 6 gennaio (epifania)
                    new DateTime(year, 5, 1),       // 1 maggio (lavoro)
                    new DateTime(year, 8, 15),      // 15 agosto (ferragosto)
                    new DateTime(year, 11, 1),      // 1 novembre (ognissanti)
                    new DateTime(year, 12, 8),      // 8 dicembre (immacolata concezione)
                    new DateTime(year, 12, 25),     // 25 dicembre (natale)
                    new DateTime(year, 12, 26)      // 26 dicembre (s. stefano)
                });
                // add easter sunday (pasqua) and monday (pasquetta)
                var easterDate = GetEasterSunday(year);
                lst.Add(easterDate);
                lst.Add(easterDate.AddDays(1));
                // country-specific holidays
                if (!String.IsNullOrEmpty(countryCode))
                {
                    switch (countryCode.ToUpper())
                    {
                        case "IT":
                            lst.Add(new DateTime(year, 4, 25));     // 25 aprile (liberazione)
                            break;
                        case "US":
                            lst.Add(new DateTime(year, 7, 4));     // 4 luglio (Independence Day)
                            break;
                        // todo: add other countries
                        case default:
                            // unsupported country: do nothing
                            break;
                    }
                }
                // city-specific holidays
                if (!String.IsNullOrEmpty(cityName))
                {
                    switch (cityName)
                    {
                        case "Rome":
                        case "Roma":
                            lst.Add(new DateTime(year, 6, 29));  // 29 giugno (s. pietro e paolo)
                            break;
                        case "Milano":
                        case "Milan":
                            lst.Add(new DateTime(year, 12, 7));  // 7 dicembre (s. ambrogio)
                            break;
                        // todo: add other cities
                        default:
                            // unsupported city: do nothing
                            break;
                    }
                }
            }
            return lst;
        }
    }
