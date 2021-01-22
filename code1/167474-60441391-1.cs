    public static class StringExtensions
    {
        public static bool? EqualsIgnoreCase(this string strA, string strB)
        {
            return strA?.Equals(strB, StringComparison.CurrentCultureIgnoreCase);
        }
    }
