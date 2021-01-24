    public static bool HasFileReadPermission(string fullPathToFile)
    {
        var accessControlList = File.GetAccessControl(fullPathToFile);
        if (accessControlList == null)
            return false;
        var accessRules = accessControlList.GetAccessRules(true, true,
            typeof(System.Security.Principal.SecurityIdentifier));
        bool allow = false, deny = false;
        foreach (FileSystemAccessRule rule in accessRules)
        {
            if ((FileSystemRights.Read & rule.FileSystemRights) == 0)
                continue;
            if (rule.AccessControlType == AccessControlType.Allow)
                allow = true;
            if (rule.AccessControlType == AccessControlType.Deny)
                deny = true;
        }
        return allow || !deny;
    }
    public static bool HasDirectoryReadPermission(string directory)
    {
        var accessControlList = Directory.GetAccessControl(directory);
        if (accessControlList == null)
            return false;
        var accessRules = accessControlList.GetAccessRules(true, true,
            typeof(System.Security.Principal.SecurityIdentifier));
        bool allow = false, deny = false;
        foreach (FileSystemAccessRule rule in accessRules)
        {
            if ((FileSystemRights.Read & rule.FileSystemRights) == 0)
                continue;
            if (rule.AccessControlType == AccessControlType.Allow)
                allow = true;
            if (rule.AccessControlType == AccessControlType.Deny)
                deny = true;
        }
        return allow || !deny;
    }
    public static IEnumerable<string> GetAllAccessibleFilesIn(string rootDirectory, string searchPattern = "*.*")
    {
        foreach (string directoryAndFileName in Directory.EnumerateFiles(rootDirectory, "*.*", SearchOption.AllDirectories))
        {
            var directory = Path.GetDirectoryName(directoryAndFileName);
            // Start by checking the directory
            if (!HasDirectoryReadPermission(directory))
                continue;
            var isSystem = (File.GetAttributes(directoryAndFileName) & FileAttributes.System) != 0;
            try
            {
                // Skip files that are system files or inaccessible
                if (!HasFileReadPermission(directoryAndFileName) || isSystem)
                    continue;
                Console.WriteLine(directoryAndFileName);
                using (var stream = File.OpenRead(directoryAndFileName))
                {
                    // I am checking file here  with my own functions.
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Things can change, guard against errors
                Console.WriteLine("I AM NOT CONTINUING " + ex.Message);
            }
            catch (IOException ex)
            {
                // Other IO (file operation) exceptions
                // don't catch "Exception" as that can hide non-related errors.
                Console.WriteLine(ex.Message);
            }
        }
    }
