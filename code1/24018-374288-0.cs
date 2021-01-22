    bool CanReadAndWrite(string path)
    {
        var perm = new System.Security.Permissions.FileIOPermission(
             System.Security.Permissions.FileIOPermissionAccess.Write |
             System.Security.Permissions.FileIOPermissionAccess.Read,
             path);
        try
        {
             perm.Demand();
             return true;
        }
        catch 
        {
             return false;
        }
    }
