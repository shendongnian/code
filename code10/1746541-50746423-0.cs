    public static class StringExtensions
    {
        public static string SubstringExact(this string src, int start, int length) 
        {
             return src.PadRight(start + length).Substring(start, length);
        } 
    } 
