    private static void DemandManagerPermission()
    {
    	// Verify the use has authority to proceed
    	string permissionGroup = ConfigurationManager.AppSettings["ManagerPermissionGroup"];
    	if (string.IsNullOrEmpty(permissionGroup))
    		throw new FaultException("Group permissions not set for access control.");
    
    	AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
    	var p = new PrincipalPermission(ServiceSecurityContext.Current.WindowsIdentity.Name, permissionGroup, true);
    	p.Demand();
    
    }
    
