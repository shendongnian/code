    public static IDictionary<Enums.Day, DateTime> GetDaysAndDateTimes(IEnumerable<Enums.Day> days)
    {
        var result = new Dictionary<Enums.Day, DateTime>();
        days.ToList().ForEach(d => result.Add(d, GetDateTime(d)));
        return result;
    }
