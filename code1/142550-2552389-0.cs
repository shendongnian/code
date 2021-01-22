    static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return (String.IsNullOrEmpty(value) || String.IsNullOrEmpty(value.Trim()));
        }
    }
