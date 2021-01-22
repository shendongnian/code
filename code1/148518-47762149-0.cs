    public static class IComparableExtensions
    {
        public static T Clamped<T>(this T value, T min, T max) 
            where T : IComparable<T>
        {
            return value.CompareTo(min) < 0 ? min : value.ClampedMaximum(max);
        }
        public static T ClampedMinimum<T>(this T value, T min)
            where T : IComparable<T>
        {
            return value.CompareTo(min) < 0 ? min : value;
        }
        public static T ClampedMaximum<T>(this T value, T max)
            where T : IComparable<T>
        {
            return value.CompareTo(max) > 0 ? max : value;
        }
    }
