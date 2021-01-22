    public class Foo
    {
      public Foo(string value) { Value=value; }
      public string Value { get; private set; }
      private static nullFoo = new Foo("default value");
      public static NullFoo { get { return nullFoo; } }
    }
