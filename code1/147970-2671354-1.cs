        public static bool HasConsecutiveChars(string source, int sequenceLength)
        {
            if (string.IsNullOrEmpty(source) || source.Length == 1) 
                return false;
            int charCount = 1;
            for (int i = 0; i < source.Length - 1; i++)
            {
                char c = source[i];
                if (Char.IsWhiteSpace(c))
                    continue;
                if (c == source[i])
                {
                    charCount++;
                    if (charCount >= sequenceLength)
                        return true;
                }
                else
                    charCount = 0;
            }
            return false;
        }
