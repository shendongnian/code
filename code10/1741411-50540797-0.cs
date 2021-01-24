        public static string RemoveRepeatedChars(string s)
        {
            if ((s == null) || (s.Length < 2))
                return s;
            // Return original string if no repeated char
            int i = 1;
            while ((i < s.Length) && (s[i] != s[i - 1]))
                i++;
            if (i == s.Length)
                return s;
            // i is index of first repeat
            var sb = new StringBuilder(s.Length - 1);
            sb.Append(s, 0, i); // add everything before the first repeat
            char prevChar = s[i];
            i++; // skip the first repeat
            for (; i < s.Length; i++)
            {
                if (s[i] != prevChar)
                {
                    sb.Append(s[i]);
                    prevChar = s[i];
                }
            }
            return sb.ToString();
        }
