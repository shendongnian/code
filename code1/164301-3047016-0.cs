    public static class EnumerableCounters
    {
        public static IEnumerable<int> Counter()
        {
            return Counter(0);
        }
        public static IEnumerable<int> Counter(int offset)
        {
            return Counter(offset, 1);
        }
        public static IEnumerable<int> Counter(int offset, int step)
        {
            for (var x = offset; ; x += step)
                yield return x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var vals = EnumerableCounters.Counter(10, 3).Take(5).ToArray();
        }
    }
