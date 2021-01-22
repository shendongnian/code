    class ClassWithDisposeAndFinalize : IDisposable
    {
        // Used to determine if Dispose() has already been called, so that the finalizer
        // knows if it needs to clean up unmanaged resources.
         private bool disposed = false;
         public void Dispose()
         {
           // Call our shared helper method.
           // Specifying "true" signifies that the object user triggered the cleanup.
              CleanUp(true);
           // Now suppress finalization to make sure that the Finalize method 
           // doesn't attempt to clean up unmanaged resources.
              GC.SuppressFinalize(this);
         }
         private void CleanUp(bool disposing)
         {
            // Be sure we have not already been disposed!
            if (!this.disposed)
            {
                 // If disposing equals true i.e. if disposed explicitly, dispose all 
                 // managed resources.
                if (disposing)
                {
                 // Dispose managed resources.
                }
                 // Clean up unmanaged resources here.
            }
            disposed = true;
          }
          // the below is called the destructor or Finalizer
         ~ClassWithDisposeAndFinalize()
         {
            // Call our shared helper method.
            // Specifying "false" signifies that the GC triggered the cleanup.
            CleanUp(false);
         }
