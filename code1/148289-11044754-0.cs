        public string FindMaxLengthPalindrome(string s)
        {
            string maxLengthPalindrome = "";
            if (s == null) return s;
            
            int len = s.Length;
            for(int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    bool found = true;
                    for (int k = j; k < (len - j) / 2; k++)
                    {
                        if (s[k] != s[len - (k - j + 1)])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        if (len - j > maxLengthPalindrome.Length)
                            maxLengthPalindrome = s.Substring(j, len - j); 
                    }
                    if(maxLengthPalindrome.Length >= (len - (i + j)))
                        break;
                }
                if (maxLengthPalindrome.Length >= (len - i))
                    break;
            }
            return maxLengthPalindrome;
        }
