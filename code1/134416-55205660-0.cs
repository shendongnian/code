    static class Program
    {
      [ThreadStatic]
      public static readonly bool IsMainThread = true;
    //...
    }
