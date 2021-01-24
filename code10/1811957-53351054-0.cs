    public static class EX
    {
        public static string IfNullOrWhiteSpace(this string s, string replacement)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return replacement;
            }
    
            return s;
        }
    }
