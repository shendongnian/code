    public static class Actions
    {
      public static void Empty() { }
      public static void Empty<T>(T value) { }
      public static void Empty<T1, T2>(T1 value1, T2 value2) { }
      /* Put as many overloads as you want */
    }
    public static class Functions
    {
      public static T Identity<T>(T value) { return value; }
      public static T0 Default<T0>() { return default(T0); }
      public static T0 Default<T1, T0>(T1 value1) { return default(T0); }
      /* Put as many overloads as you want */
    }
