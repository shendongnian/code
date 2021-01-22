    public enum LifestyleType { Singleton, Transient, PerRequest}
    public class ServiceInfo {
        public Type InterfaceType {get;set;}
        public Type ImplementationType {get;set;}
        // this might or might not be useful for your app, 
        // depending on the types of services, etc.
        public LifestyleType Lifestyle {get;set;} 
    }
    public interface IServiceRegistry {
        IEnumerable<ServiceInfo> GetServices();
    }
