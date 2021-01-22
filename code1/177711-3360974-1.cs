    class Sample
    {
      IDisposable DisposableField;
      ...
      public Sample()
      {
        var disposable = new SomeDisposableClass();
        try
        {
           DoSomething(disposable);
           DisposableField = disposable;
        }
        catch
        {
           // you have to dispose of it yourself, because
           // the exception will prevent your method/ctor from returning to the caller.
           disposable.Dispose();
           throw;
        }
      }
    }
