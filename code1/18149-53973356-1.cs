    using System;
    using System.Text.RegularExpressions;
    using static System.Text.RegularExpressions.RegexOptions;
    namespace My.Name.Space
    {
        public static class StringHelper
        {
            public static string AsOneLine(this string text, string separator = " ")
            {
                return new Regex(@"(?:\n(?:\s*))+").Replace(text, separator).Trim();
            }
        }
    }
