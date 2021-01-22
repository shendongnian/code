    System.Data.SqlClient.SqlClientPermission mPermission = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
    try
    {
        mPermission.Assert();
        //rest of your code
    }
    //Handle Exceptions
