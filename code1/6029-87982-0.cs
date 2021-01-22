    public class MyClass: IDisposable
    {
        private bool _disposed;
    
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    
        protected virtual void Dispose( bool disposing )
        {
            if( _disposed )    
                return;
    
            if( disposing )
            {
                // Dispose managed resources here
            }
    
            _disposed = true;
        }
    }
