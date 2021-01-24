     public int GetTravelDaysWithinRange( DateTime start, DateTime end, DateTime rangeStart, DateTime rangeEnd)
     {
            int days = 0;
            while (start <= end)
            {
                if (start.Month>= rangeStart.Month && start.Month <= rangeEnd.Month && start.Year >= rangeStart.Year && start.Year <= rangeEnd.Year)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
      }
