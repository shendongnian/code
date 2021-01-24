    public partial class Pressure : Page, IDisposable
        {
           // Flag: Has Dispose already been called?
           bool disposed = false;
           // Instantiate a SafeHandle instance.
           SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        
           //do your usual code
    
       // Protected implementation of Dispose pattern.
       protected virtual void Dispose(bool disposing)
       {
          if (disposed)
             return; 
          
          if (disposing) {
             handle.Dispose();
             // Free any other managed objects here.
             //
          }
          
          // Free any unmanaged objects here.
          //
          disposed = true;
       } 
        
    }
