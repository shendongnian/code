    public static class MyClassExtensions {
      public static string Name(this MyClass instance) {
        return typeof(instance).Name;
      }
    }
