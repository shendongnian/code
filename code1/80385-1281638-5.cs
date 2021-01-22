    public static bool HasWritePermissionOnDir(string path)
    {
        var writeAllow = false;
        var writeDeny = false;
        var accessControlList = Directory.GetAccessControl(path);
        if (accessControlList == null)
            return false;
        var accessRules = accessControlList.GetAccessRules(true, true, 
                                    typeof(System.Security.Principal.SecurityIdentifier));
        if (accessRules ==null)
            return false;
    
        foreach (FileSystemAccessRule rule in accessRules)
        {
            if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write) 
                continue;
            
            if (rule.AccessControlType == AccessControlType.Allow)
                writeAllow = true;
            else if (rule.AccessControlType == AccessControlType.Deny)
                writeDeny = true;
        }
    
        return writeAllow && !writeDeny;
    }
