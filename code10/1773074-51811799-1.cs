    public static string BreakCamelCase(string str) {   
      if (string.IsNullOrEmpty(str))
        return str;
    
      // We want to build string in a loop. 
      // StringBuilder has been specially desinged for this
      StringBuilder sb = new StringBuilder();
    
      foreach (var c in str) {
        if (char.IsUpper(c))    
          sb.Append(' ');
    
        sb.Append(c);
      }
    
      return sb.ToString();
    }
