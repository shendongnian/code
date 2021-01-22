    public static class StringExtension
    {
      public static string Truncate(this string s, int max) 
      { 
        return s?.Length > max ? s.Substring(0, max) : s ?? throw new ArgumentNullException(s); 
      }
    }
