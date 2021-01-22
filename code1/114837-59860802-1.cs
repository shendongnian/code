    using System;
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            if (str == null)
                return null;
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
