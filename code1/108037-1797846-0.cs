      /// <summary>
        /// Gets the weekend days.
        /// </summary>
        /// <returns></returns>
        public List<DayOfWeek> GetWeekendDays()
        {
            List<DayOfWeek> days = new List<DayOfWeek>()
                                       {
                                           DayOfWeek.Thursday,
                                           DayOfWeek.Friday,
                                           DayOfWeek.Sunday
                                       };
            return days;
        }
        /// <summary>
        /// Validates the weekend.
        /// </summary>
        /// <param name="pickupDate">The pickup date.</param>
        /// <param name="dropoffDate">The dropoff date.</param>
        /// <returns></returns>
        public bool ValidateWeekend(DateTime pickupDate, DateTime dropoffDate)
        {
            bool isValid = false;
            TimeSpan ts = dropoffDate.Subtract(pickupDate);
            if (ts.TotalDays >= 2 && ts.TotalDays <= 4)
            {
                List<DayOfWeek> days = GetWeekendDays();
                foreach (DayOfWeek day in days)
                {
                    if(pickupDate.DayOfWeek == day)
                    {
                       isValid = ValidateDropOff(dropoffDate);
                        break;
                    }
                }
            }
            return isValid;
        }
        /// <summary>
        /// Validates the drop off.
        /// </summary>
        /// <param name="dropoffDate">The dropoff date.</param>
        /// <returns></returns>
        private static bool ValidateDropOff(DateTime dropoffDate)
        {
            bool isValidDropOff = (dropoffDate.DayOfWeek == DayOfWeek.Sunday);
            if(dropoffDate.DayOfWeek == DayOfWeek.Monday)
            {
                if (dropoffDate.Hour <= 12)
                {
                    isValidDropOff = true;
                }
            }
            return isValidDropOff;
        }
