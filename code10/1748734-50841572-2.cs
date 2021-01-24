    public static class BarExtensions
    {
      public static string Something(this Ibar b)
      {
          return doSomething((dynamic)b);
      }
      public static string doSomething( bar b)
      {
         return b.a;
      }
      public static string doSomething(bar2 b)
      {
         return b.b.ToString();
      }
    }
