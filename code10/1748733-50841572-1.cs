    public static class BarExtensions
    {
      public static string Something<T>(this T b) where T : IBar
      {
          return doSomething((dynamic)b);
      }
      public string doSomething( bar b)
      {
         return b.a;
      }
      public string doSomething(bar2 b)
      {
         return b.b.ToString();
      }
    }
