    public static bool IsConsequtiveFactor(int number) {
      var factors = GetFactors(number);
      int? last = null;
      foreach ( var cur in factors ) {
        if ( last.HasValue && last.Value == cur - 1 ) {
          return true;
        }
        last = cur;
      }  
    }
    
    public static IEnumerable<int> GetFactors(int number) {
      int max = (int)Math.Sqrt(number);
      return Enumerable
        .Range(2,max-2)
        .Where(x => 0 == number % x);
    }
