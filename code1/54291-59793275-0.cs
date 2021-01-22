    public string DigitsOnly(string s)
       {
         string res = "";
         for (int i = 0; i < s.Length; i++)
         {
           if (Char.IsDigit(s[i]))
            res += s[i];
         }
         return res;
       }
