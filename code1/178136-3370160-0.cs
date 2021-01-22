    public static string RemoveSingleChars(this string str)
    {
          return str.Split(' ').Where(s => s.Length > 1).Aggregate((s, next) => s + " " + next);       
    }
    
    
    //----------Usage----------//
    
    
    var str = "This is a test.";
    var result = str.RemoveSingleChars();
