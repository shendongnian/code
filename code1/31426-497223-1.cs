        public static bool IsNumber(string s)
        {
           if (s == null || s.Length == 0)
            {
                return false;
            }
            if (s[0] == '-')
            {
                for (int i = 1; i < s.Length; i++)
                {
                    if (!char.IsDigit(s[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (char c in s)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
