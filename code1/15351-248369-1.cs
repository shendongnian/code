        private int CountMondays(DateTime startDate, DateTime endDate)
        {
            int mondayCount = 0;
            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1.0))
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
                    mondayCount++;
                }
            }
            return mondayCount;
        }
