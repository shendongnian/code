    public static class ContextFactory
    {
        private readonly ICurrentTenantService currentTenantService;
       //Inject it in the constructor
    
        public static SchoolContext MakeContext()
        {
            var currentTenant= currentTenantService.GetCurrentTenant(); //Check for NULL
                 
            return new SchoolContext(currentTenant.ConnectionString);
        }
    }
