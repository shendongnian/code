    const int DaysInPeriod = 14;
    static IEnumerable<DateTime> GetPayPeriodsInRange(DateTime start, DateTime end, bool isOdd)
    {
        var epoch = isOdd ? new DateTime(2009, 11, 1) : new DateTime(2009, 4, 1);
        var periodsTilStart = Math.Floor(((start - epoch).TotalDays) / DaysInPeriod);
        var next = epoch.AddDays(periodsTilStart * DaysInPeriod);
        if (next < start) next = next.AddDays(DaysInPeriod);
        while (next <= end)
        {
            yield return next;
            next = next.AddDays(DaysInPeriod);
        }
        yield break;
    }
    static DateTime GetPayPeriodStartDate(DateTime givenDate, bool isOdd)
    {
        var candidatePeriods = GetPayPeriodsInRange(givenDate.AddDays(-DaysInPeriod), givenDate.AddDays(DaysInPeriod), isOdd);
        var period = from p in candidatePeriods where (p <= givenDate) && (givenDate < p.AddDays(DaysInPeriod)) select p;
        return period.First();
    }
