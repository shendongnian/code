       private static int CountPatternMatches(byte[] pattern, byte[] bytes)
       {
            int counter = 0;
    
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == pattern[0] && (i + pattern.Length) < bytes.Length)
                {
                    for (int x = 1; x < pattern.Length; x++)
                    {
                        if (pattern[x] != bytes[x+i])
                        {
                            break;
                        }
    
                        if (x == pattern.Length -1)
                        {
                            counter++;
                            i = i + pattern.Length;
                        }
                    }
                }
            }
    
            return counter;
        }
