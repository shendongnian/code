    public void SomeResourceHoggingClass, IDisposable
    {
        ~SomeResourceHoggingClass()
        {
            Dispose(false);
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
    
        // virtual so a sub class can override it and add its own stuff
        //
        protected virtual void Dispose(bool deterministicDispose)
        {    
             // we can tidy managed objects
             if(deterministicDispose)
             {
                  someManagedObject.Parent.Dispose();
                  someManagedObject.Dispose();
             }
    
             DisposeUnmanagedResources();
    
             // if we've been disposed by .Dispose()
             // then we can tell the GC that it doesn't
             // need to finalise this object (which saves it some time)
             //
             GC.SuppressFinalize(this);
        }
    }
