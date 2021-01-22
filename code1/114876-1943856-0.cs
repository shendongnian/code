    public class MyClass : IDisposable
    {
        private int extHandle;
    
        public MyClass()
        {
            extHandle = // get the handle
        }
    
        public void Dispose()
        {
            Dispose(true);
    
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                // call dispose() on any managed objects you might have
            }
    
            // release the handle
        }
    
        ~MyClass()
        {
            Dispose(false);
        }
    }
