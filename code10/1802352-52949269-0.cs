    class MyClass {
      private static int s_Count;
    
      public string TName {
        get;
      }
    
      public MyClass() {
        TName = $"Name {Interlocked.Increment(ref count)}";
      }    
    }
