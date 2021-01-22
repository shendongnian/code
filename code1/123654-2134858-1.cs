        /* blah blah class junk */
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
              ReleaseManagedResources();
            }
            ReleaseUnmanagedResources();
            disposed = true;
        }
        
        // xml comments here describing whats going on lol
        protected virtual void ReleaseManagedResources(){}
        // xml comments here describing whats going on lol
        protected virtual void ReleaseUnmanagedResources(){}
        
        /* blah blah class junk */
