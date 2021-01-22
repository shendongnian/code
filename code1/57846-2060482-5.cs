    public DerivedClass : BaseClass, IDisposable (remove the IDisposable because it is inherited from BaseClass)
    protected override void Dispose( bool isDisposing )
    {
        try
        {
            if ( !this.IsDisposed )
            {
                if ( isDisposing )
                {
                    // Release all managed resources here
                    
                }
            }
        }
        finally
        {
            // explicitly call the base class Dispose implementation
            base.Dispose( isDisposing );
        }
    }
