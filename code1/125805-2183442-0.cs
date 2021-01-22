        public static string Strip(string s)
        {
            var newChars = new char[s.Length];
            int newStringIndex = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                        continue;
                    default:
                        newChars[newStringIndex++] = c;
                        break;
                }
            }
            
            return new string(newChars, 0, newStringIndex);
        }
