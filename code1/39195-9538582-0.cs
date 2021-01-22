    public abstract class Foo
    {
      protected Foo(SomeParameter x)
      {
        this.X = x;
      }
      public SomeParameter X { get; private set }
    }
    public class Bar : Foo // Bar inherits from Foo
    {
      public Bar() 
        : base(new SomeParameter("etc...")) // Bar will need to supply the constructor param
      {
      }
    }
