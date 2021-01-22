    public IdentityReferenceCollection GetUserGroups()
    {
        System.Security.Principal.WindowsIdentity currentUser =
                          System.Security.Principal.WindowsIdentity.GetCurrent();
        return currentUser.Groups;
    }
