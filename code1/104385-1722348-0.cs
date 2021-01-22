    public static class StringExtensions
    {
        public static string Right(this string str, int length)
        {
            return str.SubString(str.Length - length, length);
        }
    }
