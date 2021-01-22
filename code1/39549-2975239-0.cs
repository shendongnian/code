        public DateTime GetLastDayOfMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var lastDay = new DateTime(year, month, daysInMonth);
            while (lastDay.DayOfWeek != dayOfWeek)
            {
                lastDay = lastDay.AddDays(-1);
            }
            return lastDay;
        }
