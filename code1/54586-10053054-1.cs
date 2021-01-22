    config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
    public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
             config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
             config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            //config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
