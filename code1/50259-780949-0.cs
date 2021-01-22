     class MyClass : IDisposable
     {
        ...
        ~MyClass()
        { 
           this.Dispose(false);
        }
        public void Dispose()
        {
           this.Dispose(true);
           GC.SuppressFinalize(this);
        }
 
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            { /* dispose managed stuff also */ }
            
            /* but dispose unmanaged stuff always */
        }
     }
    
