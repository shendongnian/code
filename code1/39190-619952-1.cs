    public static class TypeHelper
    {
      public static bool HasParameterlessConstructor(Object o)
      {
        return HasParameterlessConstructor(o.GetType());
      }
      public static bool HasParameterlessConstructor(Type t)
      {
        // Usage: HasParameterlessConstructor(typeof(SomeType))
        return t.GetConstructor(new Type[0]) != null;
      }
    }
