    public class Example {
      public static void Foo(ref string name) {
        name = "foo";
      }
      public static void Test() {
        var p = new object[1];
        var info = typeof(Example).GetMethod("Foo");
        info.Invoke(null, p);
        var returned = (string)(p[0]);  // will be "foo"
      }
    }
