        public int GetDaysInMonth(DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
        public int GetDaysInNextMonth(DateTime date)
        {
            var firstDayOfThisMonth = date.AddDays(1 - date.Day); // Ensure we are dealing with day 1 of month to take care of those 30, 31 days
            var firstDayOfNextMonth = firstDayOfThisMonth.AddMonths(1); //Adding months will automatically sort out the year if need be
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
