    public static DateTime BySeconds(this DateTime d, int blockSize, int startAt = 0)
    {
        long blockTicks = TimeSpan.FromSeconds(blockSize).Ticks;
        long startTicks = TimeSpan.FromSeconds(startAt).Ticks;
        return new DateTime(((d.Ticks - startTicks) / blockTicks * blockTicks) + startTicks);
    }
