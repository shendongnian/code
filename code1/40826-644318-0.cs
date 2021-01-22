    public static class Foo
    {
      private static object barLock = new object();
      
      public static string Bar()
      {
        lock (barLock)
        {
          // Do work
          return "Done";
        }
      }
    }
