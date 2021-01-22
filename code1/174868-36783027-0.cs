	public static class StringExtensions
	{
        /* https://msdn.microsoft.com/en-us/library/aa691087(v=vs.71).aspx */
        private readonly static SortedDictionary<char, char> EscapeMap = new SortedDictionary<char, char>
        {
            { '\'', '\'' },
            { '"', '\"' },
            { '\\', '\\' },
            { '0', '\0' },
            { 'a', '\a' },
            { 'b', '\b' },
            { 'f', '\f' },
            { 'n', '\n' },
            { 'r', '\r' },
            { 't', '\t' },
            { 'v', '\v' },
        };
        public static string UnescapeSimple(this string escaped)
        {
            var sb = new StringBuilder();
            bool inEscape = false;
            var s = 0;
            for (var i = 0; i < escaped.Length; i++)
            {
                if (!inEscape && escaped[i] ==  '\\')
                {
                    inEscape = true;
                    continue;
                }
                if (inEscape)
                {
                    char mapChar;
                    if (EscapeMap.TryGetValue(escaped[i], out mapChar))
                    {
                        sb.Append(escaped.Substring(s, i - s - 1));
                        sb.Append(mapChar);
                        s = i + 1;
                    }
                    inEscape = false;
                }
            }
            sb.Append(escaped.Substring(s));
            return sb.ToString();
        }
	}
