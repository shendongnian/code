    #region IDisposable implementation
    
    //TODO remember to make this class inherit from IDisposable -> $className$ : IDisposable
 
    // Default initialization for a bool is 'false'
    private bool IsDisposed { get; set; }
        
    /// <summary>
    /// Implementation of Dispose according to .NET Framework Design Guidelines.
    /// </summary>
    /// <remarks>Do not make this method virtual.
    /// A derived class should not be able to override this method.
    /// </remarks>
    public void Dispose()
    {
        Dispose( true );
        
        // This object will be cleaned up by the Dispose method.
        // Therefore, you should call GC.SupressFinalize to
        // take this object off the finalization queue 
        // and prevent finalization code for this object
        // from executing a second time.
        
        // Always use SuppressFinalize() in case a subclass
        // of this type implements a finalizer.
        GC.SuppressFinalize( this );
    }
    
    /// <summary>
    /// Overloaded Implementation of Dispose.
    /// </summary>
    /// <param name="isDisposing"></param>
    /// <remarks>
    /// <para><list type="bulleted">Dispose(bool isDisposing) executes in two distinct scenarios.
    /// <item>If <paramref name="isDisposing"/> equals true, the method has been called directly
    /// or indirectly by a user's code. Managed and unmanaged resources
    /// can be disposed.</item>
    /// <item>If <paramref name="isDisposing"/> equals false, the method has been called by the 
    /// runtime from inside the finalizer and you should not reference 
    /// other objects. Only unmanaged resources can be disposed.</item></list></para>
    /// </remarks>
    protected virtual void Dispose( bool isDisposing )
    {
        // TODO If you need thread safety, use a lock around these 
        // operations, as well as in your methods that use the resource.
        try
        {
            if( !this.IsDisposed )
            {
                if( isDisposing )
                {
                    // TODO Release all managed resources here
                    
                    $end$
                }
                
                // TODO Release all unmanaged resources here
                
    
                
                // TODO explicitly set root references to null to expressly tell the GarbageCollector
                // that the resources have been disposed of and its ok to release the memory allocated for them.
                
                
            }
        }
        finally
        {
            // explicitly call the base class Dispose implementation
            base.Dispose( isDisposing );
   
            this.IsDisposed = true;
        }
    }
 
    //TODO Uncomment this code if this class will contain members which are UNmanaged
    // 
    ///// <summary>Finalizer for $className$</summary>
    ///// <remarks>This finalizer will run only if the Dispose method does not get called.
    ///// It gives your base class the opportunity to finalize.
    ///// DO NOT provide finalizers in types derived from this class.
    ///// All code executed within a Finalizer MUST be thread-safe!</remarks>
    //  ~$className$()
    //  {
    //     Dispose( false );
    //  }
    #endregion IDisposable implementation
