    class MyClass
    {
      [MyAttribute("Hello World")]
      public void MyMethod()
      {
        var method = typeof(MyClass).GetRuntimeMethod(nameof(MyClass.MyMethod)), new Type[]{});
        var attribute = method.GetCustomAttribute<MyAttribute>();
      }
    }
