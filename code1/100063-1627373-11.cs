    // forgive my syntax, recalling from memory
    public static class IRandomExtensions
    {
        public int GetUnbiasedInteger (this IRandom random, int modulo) { }
        public int GetUnbiasedUnsignedInteger (this IRandom random, uint modulo) { }
        public int GetUnbiasedLong (this IRandom random, long modulo) { }
        public int GetUnbiasedUnsignedLong (this IRandom random, ulong modulo) { }
        ...
    }
    public static class IEnumerableExtensions
    {
        public IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, IRandom random) 
        {
            // shuffle away!
            ...
        }
    }
