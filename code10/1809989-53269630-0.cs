    public class Foo()
    {
      private readonly Func<Bar> _barFactory;
      public Foo(Func<Bar> barFactory)
      {
        _barFactory = barFactory;
      }
    }
