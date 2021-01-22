    public static int GetBussinessDaysBetweenTwoDates(DateTime StartDate,   DateTime EndDate)
        {
            if (StartDate > EndDate)
                return -1;
            int bd = 0;
            for (DateTime d = StartDate; d < EndDate; d = d.AddDays(1))
            {
                if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                    bd++;
            }
            return bd;
        }
