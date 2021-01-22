        public static int WeekdayDifference(DateTime StartDate, DateTime EndDate)
        {
            DateTime thisDate = StartDate;
            int weekDays = 0;
            while (thisDate != EndDate)
            {
                if (thisDate.DayOfWeek != DayOfWeek.Saturday && thisDate.DayOfWeek != DayOfWeek.Sunday) { weekDays++; }
                if (EndDate > StartDate) { thisDate = thisDate.AddDays(1); } else { thisDate = thisDate.AddDays(-1); }
            }
            /* Determine if value is positive or negative */
            if (EndDate > StartDate) {
                return weekDays;
            }
            else
            {
                return weekDays * -1;
            }
        }
