    System.Security.Principal.WindowsImpersonationContext impersonationContext;
    impersonationContext = 
        ((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate();
    
    //Insert your code that runs under the security context of the authenticating user here.
    
    impersonationContext.Undo();
