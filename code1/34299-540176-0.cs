    public static void AllowIdentityToDelete(FileInfo file, string identity)
    {
        var rule = new FileSystemAccessRule(
            identity,
            FileSystemRights.Delete | FileSystemRights.DeleteSubdirectoriesAndFiles,
            AccessControlType.Allow);
        var acls = file.GetAccessControl();
        acls.AddAccessRule(rule);
        file.SetAccessControl(acls);
    }
