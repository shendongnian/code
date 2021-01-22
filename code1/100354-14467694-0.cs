    public static int WordCount(this string s)
    {
      int last = s.Length-1;
      int count = 0;
      for (int i = 0; i <= last; i++)
      {
        if ( char.IsLetterOrDigit(s[i]) &&
             ((i==last) || char.IsWhiteSpace(s[i+1]) || char.IsPunctuation(s[i+1])) )
          count++;
      }
      return count;
    }
