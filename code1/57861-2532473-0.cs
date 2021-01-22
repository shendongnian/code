    public class BaseResource: IDisposable
    {
       private IntPtr handle;
       private Component Components;
       private bool disposed = false;
       public BaseResource()
       {
       }
       public void Dispose()
       {
          Dispose(true);      
          GC.SuppressFinalize(this);
       }
       protected virtual void Dispose(bool disposing)
       {
          if(!this.disposed)
          {        
             if(disposing)
             {
                Components.Dispose();
             }         
             CloseHandle(handle);
             handle = IntPtr.Zero;
           }
          disposed = true;         
       }
       ~BaseResource()      
       {      Dispose(false);
       }
       public void DoSomething()
       {
          if(this.disposed)
          {
             throw new ObjectDisposedException();
          }
       }
    }
    public class MyResourceWrapper: BaseResource
    {
       private ManagedResource addedManaged;
       private NativeResource addedNative;
       private bool disposed = false;
       public MyResourceWrapper()
       {
       }
       protected override void Dispose(bool disposing)
       {
          if(!this.disposed)
          {
             try
             {
                if(disposing)
                {             
                   addedManaged.Dispose();         
                }
                CloseHandle(addedNative);
                this.disposed = true;
             }
             finally
             {
                base.Dispose(disposing);
             }
          }
       }
    }
