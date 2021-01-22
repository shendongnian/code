    public const int FYBeginMonth = 7, FYBeginDay = 1;
    public static int FiscalYearFromDate(DateTime date)
    {
        return date.Month > FYBeginMonth ||
               date.Month == FYBeginMonth && date.Day >= FYBeginDay ?
            date.Year : date.Year - 1;
    }
    public static IEnumerable<DateRange> FiscalYears(
                      IEnumerable<DateRange> continuousDates)
    {
        int startYear = FiscalYearFromDate(continuousDates.First().Begin),
            endYear = FiscalYearFromDate(continuousDates.Last().End);
        return from year in Enumerable.Range(startYear, endYear - startYear + 1)
               select new DateRange {
                  Begin = new DateTime(year, FYBeginMonth, FYBeginDay),
                  End = new DateTime(year + 1, FYBeginMonth, FYBeginDay)
                        .AddDays(-1) };
    }
