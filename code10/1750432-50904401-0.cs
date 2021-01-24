    public static void Main() {
      string s = "Welcome to 2018";     
      int sumofInt = s.Sum(c => c >= '0' && c <= '9' // do we have digit?
        ? c - '0'                                    // if true, take its value
        : 0);                                        // else 0
      Console.WriteLine(sumofInt);
    }  
