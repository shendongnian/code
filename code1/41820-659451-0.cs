    static int GetMonth(int Year, int Week)
    {
        DateTime tDt = new DateTime(Year, 1, 1);
        tDt.AddDays((Week - 1) * 7);
        for (int i = 0; i <= 365; ++i)
        {
            int tWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                tDt, 
                CalendarWeekRule.FirstDay, 
                DayOfWeek.Monday);
            if (tWeek == Week)
                return tDt.Month;
            tDt = tDt.AddDays(1);
        }
        return 0;
    }
