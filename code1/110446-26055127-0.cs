    public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }
    public static IEnumerable<DateTime> EachMonth(DateTime from, DateTime thru)
    {
        for (var month = from.Date; month.Date <= thru.Date || month.Month == thru.Month; month = month.AddMonths(1))
            yield return month;
    }
    public static IEnumerable<DateTime> EachDayTo(this DateTime dateFrom, DateTime dateTo)
    {
        return EachDay(dateFrom, dateTo);
    }
    public static IEnumerable<DateTime> EachMonthTo(this DateTime dateFrom, DateTime dateTo)
    {
        return EachMonth(dateFrom, dateTo);
    }
