    class MyClass : IDisposable
    {
      FileStream fs;
      void IDisposable.Dispose() { Dispose(true); }
      ~MyClass() { Dispose(false); }
      public virtual void Dispose(bool disposing) { if (disposing) fs.Dispose(); }
    }
