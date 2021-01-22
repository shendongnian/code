    public static DateTimeOffset Random(this DateTimeOffset value, TimeSpan timeSpan)
    {
        if (_threadStaticRng == null)
            _threadStaticRng = new Random();
        return value.Random(timeSpan, _threadStaticRng);
    }
    public static DateTimeOffset Random(
        this DateTimeOffset value, TimeSpan timeSpan, Random rng)
    {
        DateTimeOffset minDateTime = value.Subtract(timeSpan);
        int range = ((DateTime.Today - minDateTime)).Days;
        return minDateTime.AddDays(rng.Next(range));
    }
    [ThreadStatic]
    private static Random _threadStaticRng;
