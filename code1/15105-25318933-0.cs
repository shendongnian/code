        public static string ReplaceCaseInsensative( this string s, string oldValue, string newValue ) {
            var sb = new StringBuilder(s);
            foreach (Match match in Regex.Matches(s, Regex.Escape(oldValue), RegexOptions.IgnoreCase))
            {
                sb.Remove(match.Index, match.Length).Insert(match.Index, newValue);
            }
            return sb.ToString();
        }
