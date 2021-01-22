    AuthorizationRuleCollection acl = fileSecurity.GetAccessRules(true, true,typeof(System.Security.Principal.SecurityIdentifier));
    bool denyEdit = false;
    for (int x = 0; x < acl.Count; x++)
    {
        FileSystemAccessRule currentRule = (FileSystemAccessRule)acl[x];
        AccessControlType accessType = currentRule.AccessControlType;
        //Copy file cannot be executed for "List Folder/Read Data" and "Read extended attributes" denied permission
        if (accessType == AccessControlType.Deny && (currentRule.FileSystemRights & FileSystemRights.ListDirectory) == FileSystemRights.ListDirectory)
        {
            //we have deny copy - we can't copy the file
            denyEdit = true;
            break;
        }
    ... more checks 
    }
