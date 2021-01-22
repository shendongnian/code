    public TimeSpan? AddTime(string time1, string time2)
    {
        TimeSpan ts1;
        TimeSpan ts2;
        if (TimeSpan.TryParse(time1, out ts1) &&
            TimeSpan.TryParse(time2, out ts2))
        {
            return ts1.Add(ts2);
        }
        return null;
    }
