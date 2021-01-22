        // Stream used to require that all cleanup logic went into Close(),
        // which was thought up before we invented IDisposable.  However, we 
        // need to follow the IDisposable pattern so that users can write
        // sensible subclasses without needing to inspect all their base
        // classes, and without worrying about version brittleness, from a
        // base class switching to the Dispose pattern.  We're moving 
        // Stream to the Dispose(bool) pattern - that's where all subclasses
        // should put their cleanup starting in V2. 
        public virtual void Close() 
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }
        public void Dispose() 
        {
            Close(); 
        } 
