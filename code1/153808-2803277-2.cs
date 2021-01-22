                private bool IsDisposed
                {
                    get;set;
                }
                
                public void Dispose()
                {
                     Dispose(true);
                     GC.SuppressFinalize(this);
                }
    
                ~CLASS_NAME()
                {
                     Dispose(false);
                }
     
                protected virtual void Dispose(bool disposedStatus)
                {
                    if (!IsDisposed)
                    {
                         IsDisposed = true;
                         // Released unmanaged Resources
                         if (disposedStatus)
                         {
                          // Released managed Resources
                         }
                     }
                }
