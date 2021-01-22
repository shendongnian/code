    private void someMethod()
    {
        IEnumerable<string> roles = GetRolesForMethod("someMethod");
    
        PrincipalPermission permission = null;
        
        foreach(string role in roles)
        {
            if(permission == null)
            {
                permission = new PrincipalPermission(null, role);
            }
            else
            {
                permission = permission.Union(
                    new PrincipalPermission(null, role);
                    );
            }
        }
    
        if(permission != null)
        {
            permission.Demand();
        }
    }
