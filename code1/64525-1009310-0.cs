    public interface IInjectionWrapper
    {
        T Resolve<T>();
        object Resolve(Type service, object view);
        object Resolve(Type service);
    }
    
    public class WindsorWrapper: IInjectionWrapper
    {
        private readonly static IWindsorContainer windsor;
    
        static WindsorWrapper()
        {
            string config = ConfigurationManager.AppSettings["WindsorConfig"];
            FileResource resource = new FileResource(config);
    
            windsor = new WindsorContainer(new XmlInterpreter(resource));
        }
    
        public T Resolve<T>()
        {
            T result = windsor.Resolve<T>();
    
            return result;
        }
    
        public object Resolve(Type service)
        {
            return windsor.Resolve(service);
        }
    }
    
    public interface IResourceService
    {
        string LookupString(string key);
    }
    
    public class ResourceHelper : IResourceService
    {
        private IResourceService _resources;
    
        public ResourceHelper()
        {
            IInjectionWrapper ioc = new WindsorWrapper();
            _resources = ioc.Reslove<IResourceService>();
        }
    
        public string LookupString(string key)
        {
            return _resources.LookupString(key);
        }
    }
  
