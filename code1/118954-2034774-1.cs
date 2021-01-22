    // during login...
    string[] roles = { PermissionFlags.Create /* etc */ };
    Thread.CurrentPrincipal = new GenericPrincipal(
        new GenericIdentity("Fred"), // user
            roles);
