    public Identity(WindowsIdentity windowsIdentity)
             : base(GetToken(windowsIdentity))
    {
             init();
    }
    
    static Token GetToken(WindowsIdentity ident)
    {
        if(ident == null)
            throw new ArgumentNullException("ident");
    
        return ident.Token;
    }
