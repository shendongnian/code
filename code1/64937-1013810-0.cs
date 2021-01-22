        private static bool ContainsMetaCharacters(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            string escaped = Regex.Escape(s);
            return !escaped.Equals(s, StringComparison.Ordinal);
        }
