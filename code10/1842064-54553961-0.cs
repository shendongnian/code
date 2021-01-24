        if (role != null)
        {
            int allowed = DocumentSecurityHelper.GetNodePermissionFlags(NodePermissionsEnum.Create);
            allowed += DocumentSecurityHelper.GetNodePermissionFlags(NodePermissionsEnum.Delete);
            // Prepares a value indicating that no page permissions are denied
            int denied = 0;
    
            AclItemInfoProvider.SetRolePermissions(page, allowed, denied, role);
        }
