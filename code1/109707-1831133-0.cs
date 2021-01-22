    public static Extensions {
    
      public static char PickOneChar(this string chars, Random rnd) {
        return chars[rnd.Next(chars.Length)];
      }
    
      public static char PickOneChar(this string chars) {
        return chars.PickOneChar(new Random())
      }
    
    }
