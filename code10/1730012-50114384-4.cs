    public static class IComparableExtensions
    {
        public static bool Between<T>(this T self, T low, T high) where T : IComparable
        {
            return self.CompareTo(low) > 0 && self.CompareTo(high) < 0;
        }
    }
