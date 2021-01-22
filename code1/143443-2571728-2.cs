    int CountChars(string s, char t)
    {
       int count = 0;
       foreach (char c in s)
          if (s.Equals(t)) count ++;
       return count;
    }
.
    int CountChars(string s, char t)
    {
         return s.Length - s.Replace(t.ToString(), "").Length;
    }
