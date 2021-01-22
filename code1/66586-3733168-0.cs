    public static IEnumerable<DateTime> Intervals(DateTime start,
            DateTime end, int intervalMs)
    {
        int number = (int) ((end - start).TotalMilliseconds / intervalMs);
        return Enumerable.Range(0, number).Select(i =>
            start + TimeSpan.FromMilliseconds(intervalMs * i));
    }
