    public static class UnityContainerExtensions
    {
        public static IUnityContainer RegisterDataBaseLayer(
            this IUnityContainer container, 
            string instanceName, 
            string loggerType)
        {
            container.RegisterType<DataBaseLayer>(
                instanceName,
                new InjectionConstructor(
                    ConnectionStringParameter.Instance,
                    UsernameParameter.Instance,
                    new ResolvedParameter<ILogger>(loggerType),
                    new ResolvedParameter<ITypeMapper>()
                )
            );
            return container;
        }
    }
