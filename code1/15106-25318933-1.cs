        public static string ReplaceCaseInsensative( this string s, string oldValue, string newValue ) {
            var sb = new StringBuilder(s);
            int offset = oldValue.Length - newValue.Length;
            int matchNo = 0;
            foreach (Match match in Regex.Matches(s, Regex.Escape(oldValue), RegexOptions.IgnoreCase))
            {
                sb.Remove(match.Index - (offset * matchNo), match.Length).Insert(match.Index - (offset * matchNo), newValue);
                matchNo++;
            }
            return sb.ToString();
        }
