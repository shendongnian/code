      public static bool IsInRange<T>(this T value, T min, T max)
    where T : System.IComparable<T>
        {
            return value.IsGreaterThenOrEqualTo(min) && value.IsLessThenOrEqualTo(max);
        }
        public static bool IsLessThenOrEqualTo<T>(this T value, T other)
             where T : System.IComparable<T>
        {
            var result = value.CompareTo(other);
            return result == -1 || result == 0;
        }
        public static bool IsGreaterThenOrEqualTo<T>(this T value, T other)
             where T : System.IComparable<T>
        {
            var result = value.CompareTo(other);
            return result == 1 || result == 0;
        }
