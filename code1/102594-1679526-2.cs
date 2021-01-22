    var example = EnumerableUtils.Range(0, long.MaxValue).Where(x => (x % 2) == 0);
    // ...
    public static class EnumerableUtils
    {
        public static IEnumerable<long> Range(long start, long count)
        {
            for (long i = start; i < start + count; i++)
            {
                yield return i;
            }
        } 
    }
