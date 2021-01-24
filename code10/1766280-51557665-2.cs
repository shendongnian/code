        public int GetDaysInMonth(DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
        public int GetDaysInNextMonth(DateTime date)
        {
                        //Adding months will automatically sort out the year if need be
            var nextMonth = date.AddMonths(1);
            return DateTime.DaysInMonth(nextMonthDate.Year, nextMonthDate.Month);
        }
