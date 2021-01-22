    public static TimeSpan ToTimeSpan(this string s)
    {
        return TimeSpan.FromMilliseconds(s.Split('.', ':')
            .Zip(weights, (d, w) => Convert.ToInt64(d) * w).Sum());
    }
