    public static int ExtractWordsOutOfString(this string s, List<string> filter)
            {
                int ret = 0;
    
                string[] s1 = s.Split(' ');
    
                foreach (string eachWord in s1)
                {
                    foreach (string eachFilter in filter)
                    {
                        if (eachWord == eachFilter)
                            ret++;
                    }
                }
    
    
                return ret;
            }
