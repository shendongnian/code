    public class MyMvcJsonOptionsWrapper : IConfigureOptions<MvcJsonOptions>
    {
        IServiceProvider ServiceProvider;
        public MyMvcJsonOptionsWrapper(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }
        public void Configure(MvcJsonOptions options)
        {
            options.SerializerSettings.ContractResolver =new RoleBasedContractResolver(ServiceProvider);
        }
    }
