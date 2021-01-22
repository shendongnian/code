    public static class StringExtensions
    {
        public static string NormalizeWhitespace(this string input, char delim)
        {
            return System.Text.RegularExpressions.Regex.Replace(input.Trim(delim), "["+delim+"]{2,}", delim.ToString());
        }
    }
