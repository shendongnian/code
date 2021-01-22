    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) ||
                   ReferenceEquals(value, null) ||
                   string.IsNullOrEmpty(value.Trim(' '));
        }
    }
