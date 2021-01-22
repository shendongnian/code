    internal class FooBase : IDisposable { 
      Socket baseSocket; 
     
      private void SendNormalShutdown() { 
        // ...
      } 
     
      private bool _disposed = false; 
      public virtual void Dispose() { 
        if (!_disposed) { 
          SendNormalShutdown(); 
          baseSocket.Close(); 
        } 
      } 
    } 
     
    internal class Foo : FooBase { 
      Socket extraSocket; 
     
      private bool _disposed = false; 
      public override void Dispose() { 
        if (!_disposed) { 
          extraSocket.Close(); 
        } 
        base.Dispose(); 
      } 
    } 
