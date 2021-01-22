    public class HandlerRegistry : Registry
    {
        public HandlerRegistry()
        {
            Scan(cfg =>
            {
                cfg.TheCallingAssembly();
                cfg.IncludeNamespaceContainingType<FakeRepositories.FakeClientRepository>();
                cfg.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
            });
        }
    }
