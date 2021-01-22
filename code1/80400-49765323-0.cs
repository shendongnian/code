    string FileLocation = @"C:\test.txt";
    FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, FileLocation);
    if (SecurityManager.IsGranted(writePermission))
    {
      // you have permission
    }
    else
    {
     // permission is required!
    }
