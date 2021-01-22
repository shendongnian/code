    public int Search3(byte[] src, byte[] pattern)
        {
            int index = -1;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] != pattern[0])
                {
                    continue;
                }
                else
                {
                    bool isContinoue = true;
                    for (int j = 1; j < pattern.Length; j++)
                    {
                        if (src[++i] != pattern[j])
                        {
                            isContinoue = true;
                            break;
                        }
                        if(j == pattern.Length - 1)
                        {
                            isContinoue = false;
                        }
                    }
                    if ( ! isContinoue)
                    {
                        index = i-( pattern.Length-1) ;
                        break;
                    }
                }
            }
            return index;
        }
