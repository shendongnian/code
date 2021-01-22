    public static class StringExtensions
    {
        public static void AssertNonEmpty(this string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value must be a non-empty string.", paramName);
        }
    }
