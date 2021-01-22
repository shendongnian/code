        public static bool IsNumber(string s)
        {
            if (s == null || s.Length == 0)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
