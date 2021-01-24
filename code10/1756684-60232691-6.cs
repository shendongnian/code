    public static class ServiceProvider
    {
        public static T Get<T>(string contract = null)
        {
            T service = Locator.Current.GetService<T>(contract);
            if (service == null) throw new Exception($"IoC returned null for type '{typeof(T).Name}'.");
            return service;
        }
    
        public static T GetOrNull<T>(string contract = null)
        {
            T service = Locator.Current.GetService<T>(contract);            
            return service;
        }
    
        public static IEnumerable<T> GetAll<T>(string contract = null)
        {
            bool IsEmpty(IEnumerable<T> collection)
            {
                return collection is null || !collection.Any();
            }
    
            IEnumerable<T> services = Locator.Current.GetServices<T>(contract).ToList();
            if (IsEmpty(services)) throw new Exception($"IoC returned null or empty collection for type '{typeof(T).Name}'.");
    
            return services;
        }
    
        public static IEnumerable<T> GetAllOrNull<T>(string contract = null)
        {           
            IEnumerable<T> services = Locator.Current.GetServices<T>(contract).ToList();
            return services;
        }
    
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
