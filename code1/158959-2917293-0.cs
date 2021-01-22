        public bool IsNumeric(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsNumber(s, i) == false)
                {
                    return false;
                }
            }
            return true;
        }
