    private static EnumerationOptions GetEnumerationOptions(bool DeepScan)
    {
        EnumerationOptions mOptions = new EnumerationOptions()
        {
            Rewindable = false,        //Forward only query => no caching
            ReturnImmediately = true,  //Pseudo-async result
            DirectRead = true,         //Skip superclasses
            EnumerateDeep = DeepScan   //No recursion
        };
        return mOptions;
    }
    private static ConnectionOptions GetConnectionOptions()
    {
        ConnectionOptions connOptions = new ConnectionOptions()
        {
            EnablePrivileges = true,
            Timeout = ManagementOptions.InfiniteTimeout,
            Authentication = AuthenticationLevel.PacketPrivacy,
            Impersonation = ImpersonationLevel.Impersonate
        };
        return connOptions;
    }
