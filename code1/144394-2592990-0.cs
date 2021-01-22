    public static class StringExtensions
    {
        public static bool SubstringSearch(this string s, string value, char[] ignoreChars, out string result)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Search value cannot be null or empty.", "value");
    
            bool found = false;
            int matches = 0;
            int startIndex = -1;
            int length = 0;
    
            for (int i = 0; i < s.Length && !found; i++)
            {
                if (startIndex == -1)
                {
                    if (s[i] == value[0])
                    {
                        startIndex = i;
                        ++matches;
                        ++length;
                    }
                }
                else
                {
                    if (s[i] == value[matches])
                    {
                        ++matches;
                        ++length;
                    }
                    else if (ignoreChars != null && ignoreChars.Contains(s[i]))
                    {
                        ++length;
                    }
                    else
                    {
                        startIndex = -1;
                        matches = 0;
                        length = 0;
                    }
                }
    
                found = (matches == value.Length);
            }
    
            if (found)
            {
                result = s.Substring(startIndex, length);
            }
            else
            {
                result = null;
            }
            return found;
        }
    }
