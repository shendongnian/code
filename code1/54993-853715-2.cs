    public class GenericProxy<T>
        where T: ClientBase, new()
    {
        string _configName;
        T _proxy;
        Func<string, T> _factory;
    
        public GenericProxy(Func<string, T> factory, string configName)
        {
            _configName = configName;
            _factory = factory;
            RefreshProxy();
        }
        void RefreshProxy() // As an example; suppose we need to do this later too
        {
            _proxy = factory(_configName);
        }
    }
