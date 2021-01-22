    public static class StringNullExtensions { 
      public static bool IsNullOrEmpty(this string s) { 
        return string.IsNullOrEmpty(s); 
      } 
      public static bool IsNullOrBlank(this string s) { 
        return s == null || s.Trim().Length == 0; 
      } 
    }
