     static public bool   IsAllZero            (this string input)
            {
                if(string.IsNullOrEmpty(input))
                    return true;
                foreach (char ch in input)
                {
                    if(ch != '0')
                        return false;
                }
                return true;
            }
