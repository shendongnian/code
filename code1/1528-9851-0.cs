    public int GetWeekRows(int year, int month)
    {
        DateTime firstDay = new DateTime(year, month, 1);
        DateTime lastDay = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
        System.Globalization.Calendar c = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
        int lastWeek = c.GetWeekOfYear(lastDay, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        int firstWeek = c.GetWeekOfYear(firstDay, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        return lastWeek - firstWeek + 1;
    }
