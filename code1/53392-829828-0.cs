    public class PluginLoader : ILoader
    {
        private List<Type> _providers = new List<Type>();
        public PluginLoader()
        {
            LoadProviders();
            LoadConsumers();
        }
        public IProvider RequestProvider(Type providerType)
        {
            foreach(Type t in _providers)
            {
                if (t.GetInterfaces().Contains(providerType))
                {
                    return (IProvider)Activator.CreateInstance(t);
                }
            }
            return null;
        }
        private void LoadProviders()
        {
            DirectoryInfo di = new DirectoryInfo(PluginSearchPath);
            FileInfo[] assemblies = di.GetFiles("*.dll");
            foreach (FileInfo assembly in assemblies)
            {
                Assembly a = Assembly.LoadFrom(assembly.FullName);
                foreach (Type type in a.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(IProvider)))
                    {
                        _providers.Add(type);
                    }
                }
            }
        }
        private void LoadConsumers()
        {
            DirectoryInfo di = new DirectoryInfo(PluginSearchPath);
            FileInfo[] assemblies = di.GetFiles("*.dll");
            foreach (FileInfo assembly in assemblies)
            {
                Assembly a = Assembly.LoadFrom(assembly.FullName);
                foreach (Type type in a.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(IConsumer)))
                    {
                        IConsumer consumer = (IConsumer)Activator.CreateInstance(type);
                        consumer.Initialize(this);
                    }
                }
            }
        }
