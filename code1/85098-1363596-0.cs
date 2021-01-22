    System.Security.PermissionSet ps = 
        new System.Security.PermissionSet(System.Security.Permissions.PermissionState.None);
    ps.AddPermission(new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.NoAccess, "C:\\"));
    System.Security.Policy.PolicyLevel pl = System.Security.Policy.PolicyLevel.CreateAppDomainLevel();
    pl.RootCodeGroup.PolicyStatement = new System.Security.Policy.PolicyStatement(ps);
    AppDomain.CurrentDomain.SetAppDomainPolicy(pl);
    System.Reflection.Assembly myPluginAssembly = AppDomain.CurrentDomain.Load("MyPluginAssembly");
