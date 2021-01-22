        public static bool HasConsecutiveChars(string source, int sequenceLength)
        {
            if (string.IsNullOrEmpty(source))
                return false;
            if (source.Length == 1) 
                return false;
            int charCount = 1;
            for (int i = 0; i < source.Length - 1; i++)
            {
                char c = source[i];
                if (Char.IsWhiteSpace(c))
                    continue;
                if (c == source[i+1])
                {
                    charCount++;
                    if (charCount >= sequenceLength)
                        return true;
                }
                else
                    charCount = 1;
            }
            return false;
        }
