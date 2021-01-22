    /// <summary>
    /// Test a directory for create file access permissions
    /// </summary>
    /// <param name="DirectoryPath">Full directory path</param>
    /// <returns>State [bool]</returns>
    public static bool DirectoryCanCreate(string DirectoryPath)
    {
        if (string.IsNullOrEmpty(DirectoryPath)) return false;
    
        try
        {
            AuthorizationRuleCollection rules = Directory.GetAccessControl(DirectoryPath).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
    
            foreach (FileSystemAccessRule rule in rules)
            {
                if (identity.Groups.Contains(rule.IdentityReference))
                {
                    if ((FileSystemRights.CreateFiles & rule.FileSystemRights) == FileSystemRights.CreateFiles)
                    {
                        if (rule.AccessControlType == AccessControlType.Allow)
                            return true;
                    }
                }
            }
        }
        catch {}
        return false;
    }
