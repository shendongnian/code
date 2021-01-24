    // ***
    // *** Long Extensions
    // ***
    public static IEnumerable<long> Range(this long start, long count) => start.RangeBy(count, 1);
    public static IEnumerable<long> RangeBy(this long start, long count, long by) {
        for (; count-- > 0; start += by)
            yield return start;
    }
    public static IEnumerable<long> To(this long start, long finish) => start.ToBy(finish, 1);
    public static IEnumerable<long> ToBy(this long start, long end, long by) {
        var absBy = Math.Abs(by);
        if (start <= end)
            for (; start <= end; start += by)
                yield return start;
        else
            for (; start >= end; start -= by)
                yield return start;
    }
    public static IEnumerable<long> DownTo(this long start, long finish) => start.ToBy(finish, 1);
    public static IEnumerable<long> DownToBy(this long start, long min, long by) => start.ToBy(min, by);
