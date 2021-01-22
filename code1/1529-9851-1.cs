    public int GetWeekRows(int year, int month)
    {
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        DateTime lastDayOfMonth = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
        System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
        int lastWeek = calendar.GetWeekOfYear(lastDayOfMonth, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        int firstWeek = calendar.GetWeekOfYear(firstDayOfMonth, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        return lastWeek - firstWeek + 1;
    }
