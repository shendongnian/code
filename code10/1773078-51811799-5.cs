    public static string BreakCamelCase(string str) {   
      // "str.Length<1" will fail in case str == null. Do not re-invent the wheel
      if (string.IsNullOrEmpty(str))
        return str;
    
      // A simple Linq query:
      return string.Concat(str       // concat all chunks
       .Select(c => char.IsUpper(c)  // which can be
          ? " " + c.ToString()       //   uppercase
          : c.ToString()));          //   others 
    }
