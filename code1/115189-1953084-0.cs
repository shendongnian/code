    public static bool DoesIncludeSunday(DateTime startDate, DateTime endDate)
    {
        bool r = false;
        TimeSpan testSpan = new TimeSpan(6, 0, 0, 0);
        TimeSpan actualSpan =endDate - startDate;
        if (actualSpan >= testSpan) { r = true; }
        else
        {
            DateTime checkDate = endDate;
            while (checkDate > startDate)
            {
                r = (checkDate.DayOfWeek == DayOfWeek.Sunday);
                if(r) { break; }
                checkDate = checkDate.AddDays(-1);
            }
        }
        return r;
    }
