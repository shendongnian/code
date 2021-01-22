     /// <summary>
        /// Calculates number of business days, taking into account:
        ///  - weekends (Saturdays and Sundays)
        ///  - bank holidays in the middle of the week
        /// </summary>
        /// <param name="firstDay">First day in the time interval</param>
        /// <param name="lastDay">Last day in the time interval</param>
        /// <param name="bankHolidays">List of bank holidays excluding weekends</param>
        /// <returns>Number of business hours during the 'span'</returns>
        public static int BusinessHoursUntil(DateTime firstDay, DateTime lastDay, params DateTime[] bankHolidays)
        {
            var original_firstDay = firstDay;
            var original_lastDay = lastDay;
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay)
                return -1; //// throw new ArgumentException("Incorrect last day " + lastDay);
            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)firstDay.DayOfWeek;
                int lastDayOfWeek = lastDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }
            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;
            if (bankHolidays != null && bankHolidays.Any())
            {
                // subtract the number of bank holidays during the time interval
                foreach (DateTime bankHoliday in bankHolidays)
                {
                    DateTime bh = bankHoliday.Date;
                    if (firstDay <= bh && bh <= lastDay)
                        --businessDays;
                }
            }
            int total_business_hours = 0;
            if (firstDay.Date == lastDay.Date)
            {//If on the same day, go granular with Hours from the Orginial_*Day values
                total_business_hours = (int)(original_lastDay - original_firstDay).TotalHours;
            }
            else
            {//Convert Business-Days to TotalHours
                total_business_hours = (int)(firstDay.AddDays(businessDays).AddHours(firstDay.Hour) - firstDay).TotalHours;
            }
            return total_business_hours;
        }
