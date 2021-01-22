    public class Converter : IConverter<Foo, Bar> {
      private static _instance = new Converter;
      public static Instance { get { return _instance; } }
      public Foo ToFoo(Bar b) {return new Foo(b);}
      public Bar ToBar(Foo f) {return new Bar(f);}
    }
