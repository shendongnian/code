    public const int FYBeginMonth = 7, FYBeginDay = 1;
    public static int FiscalYearFromDate(DateTime date)
    {
        return date.Month > FYBeginMonth ||
               date.Month == FYBeginMonth && date.Day >= FYBeginDay ?
            date.Year : date.Year - 1;
    }
    public static IEnumerable<DateRangeWithPeriods>
                  FiscalYears(IEnumerable<DateRange> continuousDates)
    {
        int startYear = FiscalYearFromDate(continuousDates.First().Begin),
            endYear = FiscalYearFromDate(continuousDates.Last().End);
        return from year in Enumerable.Range(startYear, endYear - startYear + 1)
               select new DateRangeWithPeriods {
                   Range = new DateRange { Begin = FiscalYearBegin(year),
                                           End = FiscalYearEnd(year) },
          // start with the periods that began the previous FY and end in this FY
                   Periods = (from range in continuousDates
                              where FiscalYearFromDate(range.Begin) < year
                                 && FiscalYearFromDate(range.End) == year
                              select new DateRange { Begin = FiscalYearBegin(year),
                                                     End = range.End })
                              // add the periods that begin this FY
                      .Concat(from range in continuousDates
                              where FiscalYearFromDate(range.Begin) == year
                              select new DateRange { Begin = range.Begin,
                                     End = Min(range.End, FiscalYearEnd(year)) })
                              // add the periods that completely span this FY
                      .Concat(from range in continuousDates
                              where FiscalYearFromDate(range.Begin) < year
                                 && FiscalYearFromDate(range.End) > year
                              select new DateRange { Begin = FiscalYearBegin(year),
                                                     End = FiscalYearEnd(year) })
                
               };
    }
