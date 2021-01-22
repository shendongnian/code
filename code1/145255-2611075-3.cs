     public static string ArgvToCommandLine(IEnumerable<string> args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in args)
            {
                sb.Append('"');
                // Escape double quotes (") and backslashes (\).
                int searchIndex = 0;
                while (true)
                {
                    // Put this test first to support zero length strings.
                    if (searchIndex >= s.Length)
                    {
                        break;
                    }
                    int quoteIndex = s.IndexOf('"', searchIndex);
                    if (quoteIndex < 0)
                    {
                        break;
                    }
                    sb.Append(s, searchIndex, quoteIndex - searchIndex);
                    EscapeBackslashes(sb, s, quoteIndex - 1);
                    sb.Append('\\');
                    sb.Append('"');
                    searchIndex = quoteIndex + 1;
                }
                sb.Append(s, searchIndex, s.Length - searchIndex);
                EscapeBackslashes(sb, s, s.Length - 1);
                sb.Append(@""" ");
            }
            return sb.ToString(0, Math.Max(0, sb.Length - 1));
        }
        private static void EscapeBackslashes(StringBuilder sb, string s, int lastSearchIndex)
        {
            // Backslashes must be escaped if and only if they precede a double quote.
            for (int i = lastSearchIndex; i >= 0; i--)
            {
                if (s[i] != '\\')
                {
                    break;
                }
                sb.Append('\\');
            }
        }
