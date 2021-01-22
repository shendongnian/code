        public int IndexOfPatternSafe(byte[] src, byte[] pattern)
        {
            for (int x = 0; x < src.Length; x++)
            {
                byte currentValue = src[x];
                if (currentValue != pattern[0]) continue;
                bool match = false;
                for (int y = 0; y < pattern.Length; y++)
                {
                    byte tempValue = src[x + y];
                    if (tempValue != pattern[y])
                    {
                        match = false;
                        break;
                    }
                    match = true;
                }
                if (match)
                    return x;
            }
            return -1;
        }
