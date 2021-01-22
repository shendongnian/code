    void SomethingSlow() {
      using (var obj = new MyClass()) {
        // etc..
      }
    }
    
    class MyClass : IDisposable {
      private ManualResetEvent mStop = new ManualResetEvent(false);
      public Dispose() {
        mStop.Set();
      }
      // etc...
    }
