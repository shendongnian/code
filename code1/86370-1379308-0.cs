        public static string Step(this string s)
        {
            char[] stepChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] str = s.ToCharArray();
            int idx = s.Length - 1;
            char lastChar = str[idx];
            
            for (int i=0; i<stepChars.Length; i++)
            {
                if (stepChars[i] == lastChar)
                {
                    if (i == stepChars.Length - 1)
                    {
                        str[idx] = stepChars[0];
                        if (str.Length > 1)
                        {
                            string tmp = Step(new string(str.Take(str.Length - 1).ToArray()));
                            str = (tmp + str[idx]).ToCharArray();
                        }
                        else
                            str = new char[] { stepChars[0], str[idx] };
                    }
                    else
                        str[idx] = stepChars[i + 1];
                    break;
                }
            }
            return new string(str);
        }
