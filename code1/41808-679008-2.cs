    using (System.Security.Principal.WindowsImpersonationContext context = System.Security.Principal.WindowsIdentity.Impersonate(token))
    {
        // Do network operations here
        
        context.Undo();
    }
