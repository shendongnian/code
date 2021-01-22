    public static class StringExtensions
    {
        // Enable quick and more natural string.Format calls
        public static string F(this string s, params object[] args)
        {
            return string.Format(s, args);
        }
    }
