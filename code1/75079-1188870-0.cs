    try
    {
    	RegistryPermission perm1 = new RegistryPermission(RegistryPermissionAccess.Write, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
    	perm1.Demand();
    }
    catch (System.Security.SecurityException ex)
    {
    	return;
    }
    
    //Do your reg updates here
