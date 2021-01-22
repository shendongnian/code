    /// <summary>
        /// Example of how to implement the dispose pattern.
        /// </summary>
        public class PerfectDisposableClass : IDisposable
        {
            /// <summary>
            /// Type constructor.
            /// </summary>
            public PerfectDisposableClass()
            {
                Console.WriteLine( "Constructing" );    
            }
    
            /// <summary>
            /// Dispose method, disposes resources and suppresses finalization.
            /// </summary>
            public void Dispose()
            {
                Dispose( true );
                GC.SuppressFinalize(this);
            }
    
            /// <summary>
            /// Disposes resources used by class.
            /// </summary>
            /// <param name="disposing">
            /// True if called from user code, false if called from finalizer.
            /// When true will also call dispose for any managed objects.
            /// </param>
            protected virtual void Dispose(bool disposing)
            {
                Console.WriteLine( "Dispose(bool disposing) called, disposing = {0}", disposing );
    
                if (disposing)
                {
                    // Call dispose here for any managed objects (use lock if thread safety required), e.g.
                    // 
                    // if( myManagedObject != null )
                    // {
                    //     myManagedObject.Dispose();
                    //     myManagedObject = null;
                    //  }
                }
            }
    
            /// <summary>
            /// Called by the finalizer.  Note that if <see cref="Dispose()"/> has been called then finalization will 
            /// have been suspended and therefore never called.
            /// </summary>
            /// <remarks>
            /// This is a safety net to ensure that our resources (managed and unmanaged) are cleaned up after usage as
            /// we can guarantee that the finalizer will be called at some point providing <see cref="Dispose()"/> is
            /// not called.
            /// Adding a finalizer, however, IS EXPENSIVE.  So only add if using unmanaged resources (and even then try
            /// and avoid a finalizer by using <see cref="SafeHandle"/>).
            /// </remarks>
            ~PerfectDisposableClass()
            {
                Dispose(false);
            }
        }
