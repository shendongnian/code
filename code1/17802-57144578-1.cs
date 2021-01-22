        public DateTime? CalculateSLADueDate(DateTime slaStartDateUTC, double slaDays)
        {
            if (slaDays < 0)
            {
                return null;
            }
            var dayCount = slaDays;
            var dueDate = slaStartDateUTC;
            var blPublicHoliday = new PublicHoliday();
            IList<BusObj.PublicHoliday> publicHolidays = blPublicHoliday.SelectAll();
            do
            {
                dueDate = dueDate.AddDays(1);
                if ((dueDate.DayOfWeek != DayOfWeek.Saturday)
                && (dueDate.DayOfWeek != DayOfWeek.Sunday)
                && !publicHolidays.Any(x => x.HolidayDate == dueDate.Date))
                {
                    dayCount--;
                }
            }
            while (dayCount > 0);
            return dueDate;
        }
