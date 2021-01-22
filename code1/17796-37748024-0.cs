        public static DateTime AddWorkingDays(this DateTime date, int daysToAdd)
        {
            while (daysToAdd > 0)
            {
                date = date.AddDays(1);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysToAdd -= 1;
                }
            }
            return date;
        }
