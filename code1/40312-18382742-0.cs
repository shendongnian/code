    public static class StringExtensions
    {
        public static string[] Split(this string text, char escapeChar, params char[] seperator)
        {
            return Split(text, escapeChar, seperator, StringSplitOptions.None);
        }
        public static string[] Split(this string text, char escapeChar, char[] seperator, int count)
        {
            return Split(text, escapeChar, seperator, count, StringSplitOptions.None);
        }
        public static string[] Split(this string text, char escapeChar, char[] seperator, StringSplitOptions options)
        {
            return Split(text, escapeChar, seperator, int.MaxValue, options);
        }
        public static string[] Split(this string text, char escapeChar, char[] seperator, int count, StringSplitOptions options)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            if (text.Length == 0)
            {
                return new string[0];
            }
            var segments = new List<string>();
            bool previousCharIsEscape = false;
            var segment = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (previousCharIsEscape)
                {
                    previousCharIsEscape = false;
                    if (seperator.Contains(text[i]))
                    {
                        // Drop the escape character when it escapes a seperator character.
                        segment.Append(text[i]);
                        continue;
                    }
                    // Retain the escape character when it escapes any other character.
                    segment.Append(escapeChar);
                    segment.Append(text[i]);
                    continue;
                }
                if (text[i] == escapeChar)
                {
                    previousCharIsEscape = true;
                    continue;
                }
                if (seperator.Contains(text[i]))
                {
                    if (options != StringSplitOptions.RemoveEmptyEntries ||
                        segment.Length != 0)
                    {
                        // Only add empty segments when options allow.
                        segments.Add(segment.ToString());
                    }
                    segment = new StringBuilder();
                    continue;
                }
                segment.Append(text[i]);
            }
            return segments.ToArray();
        }
    }
