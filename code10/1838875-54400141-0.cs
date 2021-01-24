    public class Foo
    { 
      public int Number { get; private set; }
      public IList<ISomething> IsSomething { get; private set; }
      public Foo(int number, IList<Something> concreteType)
      {
        Number = number;
        // convert here, creates a new list
        IsSomething = concreteType.ConvertAll(x => (ISomething)x);
      }
    }
