    private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
    {
        var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
        var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
        var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));
        return d1 == d2;
    }
