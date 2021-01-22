    public static class StringExtensions
    {
        public static string TrimLastCharacter(this string str, char character)
        {
            if (string.IsNullOrEmpty(str) || str[str.Length - 1] != character)
            {
                return str;
            }
            return str.Substring(0, str.Length - 1);
        }
    }
