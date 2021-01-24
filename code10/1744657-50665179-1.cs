    private DateTime GetDay(DayOfWeek dayName, DateTime dt)
    {
        if (dt.DayOfWeek == dayName)
                return dt;
            while (dt.DayOfWeek != dayName)
            {
                if (dayName == DayOfWeek.Monday)
                    dt = dt.AddDays(-1);
                else
                    dt = dt.AddDays(1);
            }
            return dt;
    }
