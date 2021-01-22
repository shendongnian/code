    public enum MyType { Foo, Bar, Baz };
    public static class MyTypeExtension
    {
       public static MyType GetMyType(this Foo o)
       {
          return MyType.Foo;
       }
       public static MyType GetMyType(this Bar o)
       {
          return MyType.Bar;
       }
       public static MyType GetMyType(this Baz o)
       {
          return MyType.Baz;
       }
    }
