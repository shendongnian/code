    public Int32 GetWeekForDateCurrentCulture(DateTime dt)
    {
        Culture cultire = Thread.CurrentThread.CurrentCulture;
        Calendar cal = culture.Calendar;
        return cal.GetWeekOfYear(DateTime.Today,
            culture.DateTimeFormat.CalendarWeekRule,
            culture.DateTimeFormat.FirstDayOfWeek);
    }
    public Int32 GetWeekSpanCountForMonth(DateTime dt)
    {
        DateTime firstDayInMonth = new DateTime(dt.Year, dt.Month, 1);
        DateTime lastDayInMonth = firstDayInMonth.AddMonths(1);
        return
            GetWeekForDateCurrentCulture(lastDayInMonth)
            - GetWeekForDateCurrentCulture(firstDayInMonth)
            + 1;
    }
