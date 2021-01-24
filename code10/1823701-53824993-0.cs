    public static class MyClass
    {
      public static void MyMethod<T>(T t) where T : class
      {
         t.ToString(); // Note: for this to work we need to KNOW the type which defines `method`.
      }
    }
