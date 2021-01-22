    public static class MyGlobals
    {
      public static string Global1 = "Hello";
      public static string Global2 = "World";
    }
    
    public class Foo
    {
    
        private void Method1()
        {
           string example = MyGlobals.Global1;
           //etc
        }
    }
