     public static bool SetAcl(string filename, string account)
    {
        FileSystemAccessRule rule = new FileSystemAccessRule(account, FileSystemRights.Write, AccessControlType.Allow);
        PermissionSet fp = new PermissionSet(PermissionState.Unrestricted);
        fp.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, new string[] { filename }));
        fp.AddPermission(new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.PathDiscovery, new string[] { filename }));
        fp.Assert();
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(filename));
        bool what = false;
        DirectorySecurity security = di.GetAccessControl();
        security.ModifyAccessRule(AccessControlModification.Add, rule, out what);
        di.SetAccessControl(security);
        return what;
    }
