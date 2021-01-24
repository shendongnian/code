    public static string BreakCamelCase(string str) {   
      if (string.IsNullOrEmpty(str))
        return str;
      return Regex.Replace(str, @"(\p{Lu})", " $1");
    }
