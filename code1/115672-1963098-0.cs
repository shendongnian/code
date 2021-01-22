    public static class StringExtensions
    {
        public static bool In(this string @this, params string[] strings)
        {
            return strings.Contains(@this); 
        }
    }
