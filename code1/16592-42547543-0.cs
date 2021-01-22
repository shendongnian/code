    var fileIOPermission = new FileIOPermission(
    	FileIOPermissionAccess.Read,
    	System.Security.AccessControl.AccessControlActions.View,
    	MyPath);
    if (fileIOPermission.AllFiles == FileIOPermissionAccess.Read)
    {
    	// Do your thing here...
    }
