    class Foo : IDisposable
    {
      public void Dispose()
      {
        Console.WriteLine("Disposed");
      }
      ~Foo()
      {
        Console.WriteLine("Finalized");
      }
    }
    ...
    public void Go()
    {
      Foo foo = new Foo();
    }
