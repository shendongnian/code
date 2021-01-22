        private string GetInt(string s)
        {
            int i = 0;
            
            s = s.Trim();
            while (i<s.Length && char.IsDigit(s[i])) i++;
            return s.Substring(0, i);
        }
