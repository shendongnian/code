    foreach (FileSystemAccessRule fileSystemAccessRule in folderSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
    {
        string IdentityReference = fileSystemAccessRule.IdentityReference.ToString();
    
        AccessControlType accessControlType = fileSystemAccessRule.AccessControlType;
        FileSystemRights filesystemrights = fileSystemAccessRule.FileSystemRights;
        bool isInherited = fileSystemAccessRule.IsInherited;
    
        // .. Get specific permissions ...
        bool allowControlType = accessControlType == AccessControlType.Allow;
        bool canRead = (filesystemrights & FileSystemRights.Read) == FileSystemRights.Read;
        bool canWrite = (filesystemrights & FileSystemRights.Write) == FileSystemRights.Write;
        bool canExecute = (filesystemrights & FileSystemRights.ExecuteFile) == FileSystemRights.ExecuteFile;
    
        // ... Any more specific permissions ...
    
        dataGridView1.Rows.Add(IdentityReference, allowControlType, canRead, canWrite, canExecute, ... );
    }
