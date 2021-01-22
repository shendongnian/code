        static public int SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            int matches = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (pattern[0] == bytes[i] && bytes.Length - i >= pattern.Length)
                {
                    bool ismatch = true;
                    for (int j = 1; j < pattern.Length && ismatch == true; j++)
                    {
                        if (bytes[i + j] != pattern[j])
                            ismatch = false;
                    }
                    if (ismatch)
                    {
                        matches++;
                        i += pattern.Length - 1;
                    }
                }
            }
            return matches;
        }
