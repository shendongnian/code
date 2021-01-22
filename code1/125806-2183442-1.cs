        public static unsafe string StripWhitespace(string s)
        {
            int len = s.Length;
            char* newChars = stackalloc char[len];
            int newStringIndex = 0;
            for (int i = 0; i < len; ++i)
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
