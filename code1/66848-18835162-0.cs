        public static DateTime AddBusinessDays(DateTime date, int days)
        {
            if (days == 0) return date;
            int i = 0;
            while (i < days)
            {
                if (!(date.DayOfWeek == DayOfWeek.Saturday ||  date.DayOfWeek == DayOfWeek.Sunday)) i++;  
                date = date.AddDays(1);
            }
            return date;
        }
