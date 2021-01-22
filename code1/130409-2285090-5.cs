    public class ManagedDisposable : IDisposable {
    
      // ...
    
      public virtual void Dispose() {
        _otherDisposable.Dispose();
      }
    
      IDisposable _otherDisposable;
    
    }
