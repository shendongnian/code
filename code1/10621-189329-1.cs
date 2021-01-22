    public class ServiceContainer : IDisposable
    {
        readonly IList<IService> services = new List<IService>();
        public void Add<T>(T service)
        {
            Add<T,T>(service);
        }
        public void Add<Key, T>(T service) where T : Key
        {
             services.Add(new Service<Key>(this, service));
        }
        public void Dispose()
        {
            foreach(var service in services)
                service.Remove(this);
        }
        ~ServiceContainer()
        {
            Dispose();
        }
        public T Get<T>()
        {
            return Service<T>.Get(this);
        }
    }
    public interface IService
    {
        void Remove(object parent);
    }
    public class Service<T> : IService
    {
        static readonly Dictionary<object, T> services = new Dictionary<object, T>();
        public Service(object parent, T service)
        {
            services.Add(parent, service);
        }
        public void Remove(object parent)
        {
            services.Remove(parent);
        }
        public static T Get(object parent)
        {
            return services[parent];
        }
    }
