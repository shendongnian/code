    class ConstructorAbortedException : Exception { }
    
    class Foo
    {
      public Foo()
      {
        if(goesWrong)
        {
          throw new ConstructorAbortedException();
        }
      }
    }
    
    void Bar()
    {
      try
      {
        Foo f = new Foo();
      }
      catch(ConstructorAbortedException)
      {
        //..
      }
    }
