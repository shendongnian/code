    class TheUltimateFactory
    {
        private readonly IDictionary<Type,IFactory> _factories;
        public TheUltimateFactory(IFactory[] factories)
        {
            _factories = factories.ToDictionary(f => GetFactoryType(f.GetType()), f => f);
        }
        private Type GetFactoryType(Type type)
        {
            var genericInterface = type.GetInterfaces().First(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IFactory<>));
            return genericInterface.GetGenericArguments()[0];
        }
        public IMadeThis MakeIt(IConfig config)
        {
            var configType = config.GetType();
            var method = typeof(IFactory<>).MakeGenericType(configType).GetMethod("MakeIt");
            return (IMadeThis)method.Invoke(_factories[configType], new object[]{config});
        }
    }
