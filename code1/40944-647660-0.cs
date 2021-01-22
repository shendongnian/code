    public static class StringExtensions
    {
        public static bool IsNullOrBlank(this string s)
        {
            return s == null || s.Trim().Length == 0;
        }
    }
