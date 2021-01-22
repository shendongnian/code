    private static TimeSpan GetLatestSpan(IEnumerable<int> monthNumbers, DateTime startDate)
    {
      var candidateDates = monthNumbers
                        .Select(month => GetNearestDateInDifferentMonthWithSameDay(startDate, month));
    
      return candidateDates.Max() - startDate;
    }
    
    private static DateTime GetNearestDateInDifferentMonthWithSameDay(DateTime startDate, int month)
    {
     return new DateTime(month > startDate.Month ? startDate.Year : startDate.Year + 1, month, startDate.Day);
    }
