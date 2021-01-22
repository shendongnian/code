    using System;
    using System.IO;
    
    public class ResourceManager : IDisposable
    {
        private Stream _resource;
        private bool _disposed;
    
        public void Dispose()
        {
            Dispose(true);
    
            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }
    
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Exiting Process. Cleaning up.");
                    // free resources here
                    if (_resource != null)
                        _resource.Dispose();
                    Console.WriteLine("Object disposed.");
                }
    
                // Indicate that the instance has been disposed.
                _resource = null;
                _disposed = true;
            }
        }
    }
