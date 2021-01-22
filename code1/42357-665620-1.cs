    public class Foo
    {
      public Foo(string value) { Value=value; }
      public string Value { get; private set; }
      private static Foo nullFoo = new Foo("default value");
      public static Foo NullFoo { get { return nullFoo; } }
    }
