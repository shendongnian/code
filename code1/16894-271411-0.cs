    public static class StringExtension
    {
        public static string F(this string s, params object[] args)
        {
            return string.Format(s, objects);
        }
    }
