      public class Foo<T> {
        public string Bar(T value) { return "Called Bar(T)"; }
        public string Bar(int value) { return "Called Bar(int)"; }
        public static void CallBar<TR>(Foo<TR> foo) {
    
          var footinfo = typeof(Foo<>).GetMethods();
          int i;
          for (i = 0; i < footinfo.Count(); ++i) {
            if (footinfo[i].Name == "Bar" && footinfo[i].GetParameters()[0].ParameterType.IsGenericParameter == false)
              break;
          }
    
          Console.WriteLine(foo.GetType().GetMethods()[i].Invoke(foo, new object[] { 0 }));
        }
      }
      // prints Bar(int)...
      Foo<int>.CallBar( new Foo<int>() );
