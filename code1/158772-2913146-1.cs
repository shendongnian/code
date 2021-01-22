    class MyClass : IDisposable {
      private IntPtr SomeNativeResource;
      ~MyClass() {
        Dispose(false);
      }
      public void Dispose() {
        Dispose(true);
      }
      protected virtual void Dispose(bool disposing) {
        if (disposing) {
          // Dispose any disposable fields here
          GC.SuppressFinalize(this);
        }
        ReleaseNativeResource();
      }
    }
