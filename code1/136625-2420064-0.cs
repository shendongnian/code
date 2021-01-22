    class GenericComparation {
        public static bool IsGreaterThanZero<T>(T value) where T : IComparable<T> {
            // Console.WriteLine(value.GetType().Name)
            return value.CompareTo(default(T)) > 0;
        }
    }
