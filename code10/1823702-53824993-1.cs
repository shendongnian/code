    public class MyBase
    {
       void Method();
    }
    
    public static class MyClassForBase
    {
      public static void MyMethod<T>(T t) where T : MyBase
      {
         t.Method(); // Note: anything from MyBase is now available
      }
    }
