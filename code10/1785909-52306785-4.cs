    static void Main(string[] args)
    {
       var result = Combos(1200);
    }
        
    static Dictionary<long, long> cache = new Dictionary<long, long>();
    public static long Combos(long n)
    {           
       if (n < 3)
       {
          return n;
       }
       else
       {
          if (!cache.TryGetValue(n - 1, out long combos1))
          {
              combos1 = Combos(n - 1);
              cache.Add(n - 1, combos1);
          }
          if (!cache.TryGetValue(n - 2, out long combos2))
          {
              combos2 = Combos(n - 2);
              cache.Add(n - 2, combos2);
          }
          return combos1 + combos2;
       }
    }
