    public static class Extensions {
    
      private static Dictionary<Type, Action<Base>> callFoo = new Dictionary<Type, Action<Base>>
      {
        {typeof(B), b => (b as B).Foo()},
        {typeof(C), c => (c as C).Foo()}
      };
    
      public static void Foo(this Base obj) {
          try {
            callFoo[typeof(obj)](obj);
          }
          catch (RuntimeBinderException ex) {
              Console.WriteLine(ex.Message);
          }
      }
    
      public static void Foo(this B b) {
          Console.WriteLine("Foo in B");
      }
    
      public static void Foo(this C c) {
          Console.WriteLine("Foo in C");
      }
    
    }
