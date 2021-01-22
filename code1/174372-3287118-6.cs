    public struct DateRange
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
    public class DateRangeWithPeriods
    {
        public DateRange Range { get; set; }
        public IEnumerable<DateRange> Periods { get; set; }
    }
    private static DateTime Min(DateTime a, DateTime b)
    {
        return a < b ? a : b;
    }
    public static DateTime FiscalYearBegin(int year)
    {
        return new DateTime(year, FYBeginMonth, FYBeginDay);
    }
    public static DateTime FiscalYearEnd(int year)
    {
        return new DateTime(year + 1, FYBeginMonth, FYBeginDay).AddDays(-1);
    }
