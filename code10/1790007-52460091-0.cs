    bool StringEquals(string string1, string string2)
        {
            foreach (char ch in string1)
            {
                if (!string2.Contains(ch))
                {
                    return false;
                }
            }
            return true;
        }
