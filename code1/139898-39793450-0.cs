    class ClassOfMyMethod
    {
      [MyAttribute("Hello World")]
      public int MyMethod()
      {
        var method = typeof(ClassOfMyMethod).GetRuntimeMethod(nameof(ClassOfMyMethod.MyMethod)), new Type[]{});
        var attribute = method.GetCustomAttribute<MyAttribute>();
      }
    }
