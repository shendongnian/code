    public class BetterDisposableClass : IDisposable {
    
      public void Dispose() {
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
    
      ~BetterDisposableClass() {
        CleanUpNativeResources();
      }
    
    }
