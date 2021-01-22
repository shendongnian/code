    public static DateTimeOffset Random(this DateTimeOffset value, TimeSpan timeSpan)
    {
        double seconds = timeSpan.TotalSeconds * StaticRandom.Instance.NextDouble();
        // Alternatively: return value.AddSeconds(-seconds);
        TimeSpan span = TimeSpan.FromSeconds(seconds);
        return value - span;
    }
