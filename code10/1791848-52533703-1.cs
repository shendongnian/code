    public static class Bootstrapper
    {
        // assuming Username is a configuration setting stored in the config file
        private static string Username => ConfigurationManager.AppSettings["username"];
        // assuming ConnectionString is a connection string stored in the config file
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public static IUnityContainer Setup()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ITypeMapper, TypeMapper>();
            container.RegisterType<DataBaseLayer>(new InjectionFactory(CreateDataBaseLayer));
            return container;
        }
        private static DataBaseLayer CreateDataBaseLayer(IUnityContainer container)
        {
            ILogger logger = container.Resolve<ILogger>();
            ITypeMapper mapper = container.Resolve<ITypeMapper>();
            return new DataBaseLayer(ConnectionString, Username, logger, mapper);
        }
    }
