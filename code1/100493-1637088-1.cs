    public static class StringExtensions
    {
        public static string Collapse(this string str)
        {
            return str.Collapse(' ');
        }
        public static string Collapse(this string str, char delimiter)
        {
            str = str.Trim(delimiter);
            string delim = delimiter.ToString();
            return Regex.Replace(str, Regex.Escape(delim) + "{2,}", delim);
        }
    }
