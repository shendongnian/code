    **[System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]**  
    public class MyDataService : DataService<...>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(IDataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            
            **config.UseVerboseErrors = true;**
        }
