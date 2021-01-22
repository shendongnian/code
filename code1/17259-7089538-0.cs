    static public string ToFaString         (this string value)
            {
                // 1728 , 1584
                string result = "";
                if (value != null)
                {
                    char[] resChar = value.ToCharArray();
                    for (int i = 0; i < resChar.Length; i++)
                    {
                        if (resChar[i] >= '0' && resChar[i] <= '9')
                            result += (char)(resChar[i] + 1728);
                        else
                            result += resChar[i];
                    }
                }
                return result;
            }
