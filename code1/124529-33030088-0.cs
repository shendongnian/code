     new   System.Security.Permissions.RegistryPermission(System.Security.Permissions.PermissionState.Unrestricted).Assert();
    try
    {
    //Your code
    }catch
    {
    }finally
    {
           System.Security.Permissions.RegistryPermission.RevertAssert();
    }
