    public class PluginContainer
    {
        public IPlugin LoadPlugin<T>(IResourceContext context) where T: PluginFactory, new()
        {
            var factory = new T();
            return factory.Create(context);
        }
    }
