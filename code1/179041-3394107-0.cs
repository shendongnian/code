    public static void AddDirectorySecurity(string FileName, string Account, 
                          FileSystemRights Rights, AccessControlType ControlType)
    {
        // Create a new DirectoryInfo object.
        DirectoryInfo dInfo = new DirectoryInfo(FileName);
        // Get a DirectorySecurity object that represents the 
        // current security settings.
        DirectorySecurity dSecurity = dInfo.GetAccessControl();
        // Add the FileSystemAccessRule to the security settings. 
        dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                        Rights,
                                                        ControlType));
        // Set the new access settings.
        dInfo.SetAccessControl(dSecurity);
    }
