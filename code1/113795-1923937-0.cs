    private static WindowsIdentity ValidateIdentity( WindowsIdentity identity )
    {
        if( identity == null )
            throw new ArgumentNullException( "identity" );
        // possibly some other validation checks here...
        return identity;        
    }
    public Identity(WindowsIdentity windowsIdentity)
        : base( ValidateIdentity( windowsIdentity ).Token )
    {
         init();
    }
