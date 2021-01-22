        public static List<DateTime> GetWeeks(this DateTime month, DayOfWeek startOfWeek)
        {
            var firstOfMonth = new DateTime(month.Year, month.Month, 1);
            var firstStartOfWeek = firstOfMonth.AddDays((Int32)firstOfMonth.DayOfWeek + (Int32)startOfWeek % 7);
            var current = firstStartOfWeek;
            var weeks = new List<DateTime>();
            while (current.Month == month.Month)
            {
                weeks.Add(current);
                current = current.AddDays(7);
            }
            return weeks;
        }
