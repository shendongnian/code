        private static bool ContainsMetaCharacters(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (Regex.Escape(s.Substring(i,1))[0] != s[i])
                {
                    return true;
                }
            }
            return false;
        }
