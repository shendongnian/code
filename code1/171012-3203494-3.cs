     public static void Foo(this Base obj) {
          try {
            Foo_(obj as dynamic);
          }
          catch (RuntimeBinderException ex) {
              Console.WriteLine(ex.Message);
          }
      }
      private static void Foo_(B b) {
          Console.WriteLine("Foo in B");
          b.ListOfBs.ForEach(x => x.Foo());
      }
      private static void Foo_(C c) {
          Console.WriteLine("C.Name = {0}", c.Name);
      }
