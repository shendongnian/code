    public static Int32 GetWeekForDateCurrentCulture(DateTime dt)
    {
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        Calendar cal = culture.Calendar;
        return cal.GetWeekOfYear(dt,
            culture.DateTimeFormat.CalendarWeekRule,
            culture.DateTimeFormat.FirstDayOfWeek);
    }
    public static Int32 GetWeekSpanCountForMonth(DateTime dt)
    {
        DateTime firstDayInMonth = new DateTime(dt.Year, dt.Month, 1);
        DateTime lastDayInMonth = firstDayInMonth.AddMonths(1).AddDays(-1);
        return
            GetWeekForDateCurrentCulture(lastDayInMonth)
            - GetWeekForDateCurrentCulture(firstDayInMonth)
            + 1;
    }
