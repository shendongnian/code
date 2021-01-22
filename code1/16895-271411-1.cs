    public static class StringExtensions
    {
        public static string F(this string s, params object[] args)
        {
            return string.Format(s, objects);
        }
    }
