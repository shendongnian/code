    public static class BetweenExtension
        {
            public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable
            {
                return (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
            }
        }
