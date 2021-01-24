<!-- -->
    public static class Extensions
    {
        public static bool IsNullEmpty<T>(this T valueToCheck) 
        {
            return valueToCheck == null || EqualityComparer<T>.Default.Equals(valueToCheck, default(T));
        }
    }
