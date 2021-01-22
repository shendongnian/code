    public IEnumerable<DateTime> GetDates(DateTime begin, int count)
    {
        var first = new DateTime(begin.Year, begin.Month, begin.Day);
        var maxYield = Math.Abs(count);
        for (int i = 0; i < maxYield; i++)
        {
            if(count < 0)
                yield return first - TimeSpan.FromDays(i);
            else
                yield return first + TimeSpan.FromDays(i);		
        }
        yield break;
    }
    public IEnumerable<DateTime> GetDates(DateTime begin, DateTime end)
    {
        var days = (int)Math.Ceiling((end - begin).TotalDays);
        return GetDates(begin, days);
    }
