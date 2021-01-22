    static void Main(string[] args)
    {
        DirectoryInfo dInfo = new DirectoryInfo(@"C:\Test\Folder");
        DirectorySecurity dSecurity = dInfo.GetAccessControl();
        ReplaceAllDescendantPermissionsFromObject(dInfo, dSecurity);
    }
    
    static void ReplaceAllDescendantPermissionsFromObject(
        DirectoryInfo dInfo, DirectorySecurity dSecurity)
    {
        // Copy the DirectorySecurity to the current directory
        dInfo.SetAccessControl(dSecurity);
    
        foreach (FileInfo fi in dInfo.GetFiles())
        {
            // Get the file's FileSecurity
            var ac = fi.GetAccessControl();
    
            // inherit from the directory
            ac.SetAccessRuleProtection(false, false);
    
            // apply change
            fi.SetAccessControl(ac);
        }
        // Recurse into Directories
        dInfo.GetDirectories().ToList()
            .ForEach(d => ReplaceAllDescendantPermissionsFromObject(d, dSecurity));
    }
