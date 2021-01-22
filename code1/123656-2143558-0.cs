    public class DisposableClass : IDisposable {
      void IDisposable.Dispose() {
        CleanUpManagedResources();
        CleanUpNativeResources();
        GC.SuppressFinalize(this);
      }
      protected virtual void CleanUpManagedResources() { 
        // ...
      }
      protected virtual void CleanUpNativeResources() {
        // ...
      }
      ~DisposableClass() {
        CleanUpNativeResources();
      }
    }
