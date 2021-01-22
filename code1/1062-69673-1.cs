    class MyClass<T>
    {
      private readonly T _value;
      private MyClass(T value) { _value = value; }
      public static MyClass<int> FromInt32(int value) { return new MyClass<int>(value); }
      public static MyClass<string> FromString(string value) { return new MyClass<string>(value); }
      // etc for all the primitive types, or whatever other fixed set of types you are concerned about
    }
