    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhitespace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim());
        }
    }
