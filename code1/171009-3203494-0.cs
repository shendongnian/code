     public static void Foo(this Base obj) {
          dynamic dynobj = obj;
          try {
            Foo(dynobj);
          }
          catch (RuntimeBinderException ex) {
              Console.WriteLine(ex.Message);
          }
      }
      private static void Foo(B b) {
          Console.WriteLine("Foo in B");
      }
