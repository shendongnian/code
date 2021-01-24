    DirectoryInfo permissionChecker = new DirectoryInfo(dirPath);
    try
    {
        permissionChecker.GetAccessControl();
        System.Security.AccessControl.DirectorySecurity permissionCheckerDS = permissionChecker.GetAccessControl();
    }
    catch (UnauthorizedAccessException ex)
    {
        Console.WriteLine(dirPath);
        // Here when the UnauthorizedAccessException occurs, it means that the user has no access for that directory (not even read access) 
    }
