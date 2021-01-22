    DirectorySecurity directorySecurity = Directory.GetAccessControl(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
    FileSystemAccessRule accessRule
        = new FileSystemAccessRule(@"BUILTIN\Users", FileSystemRights.FullControl, 
            InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, 
            PropagationFlags.None, 
            AccessControlType.Allow);
    bool modified=false;
    directorySecurity.ModifyAccessRule(AccessControlModification.Add,
        accessRule,
        out modified);
    if (modified)
    {
        source.Create(directorySecurity);
    }
    else
    {
        source.Create();
    }
