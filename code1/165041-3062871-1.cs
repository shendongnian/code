        public List<DateTime> GetWeeks(DayOfWeek weekStart, DateTime startDate)
        {
            List<DateTime> result = new List<DateTime>();
            DateTime current = DateTime.Today.AddDays(weekStart - DateTime.Today.DayOfWeek);
            while (current >= startDate)
            {
                result.Add(current);
                // move to the previous week
                current = current.AddDays(-7);
            }
            return result;
        }
