    var example = EnumerableUtils.Range(0, long.MaxValue).Where(x => (x % 2) == 0);
    // ...
    public static class EnumerableUtils
    {
        public static IEnumerable<long> Range(long start, long length)
        {
            for (long i = 0; i < length; i++)
            {
                yield return start + i;
            }
        } 
    }
