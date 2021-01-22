    [SecurityPermission(SecurityAction.Deny, Flags = SecurityPermissionFlag.NoFlags ^ SecurityPermissionFlag.Assertion)]
    void CallExternalAssemblyClass(ExternalClass c)
    {
        c.SomeMethod();
    }
