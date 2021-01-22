    void Main()
    {
      "hello".Pascal().Dump();	
    }
    
    public static class MyExtensions
    {
      public static string Pascal (this string s)
      {
        return char.ToLower (s[0]) + s.Substring(1);
      }
    }
