    public interface ICACServiceFactory
    {
        CACService Create();
    }
    // A factory responsible for creating a 'real' version
    public class RemoteCACServiceFactory : ICACServiceFactory
    {
        public CACService Create()
        {
             return new CACService(new UserRepository(), new BusinessRepository());
        }        
    }
    // Returns a service configuration for local runs & unit testing
    public class LocalCACServiceFactory : ICACServiceFactory
    {
        public CACService Create()
        {
             return new CACService(
                   new MemoryUserRepository(), 
                   new MemoryBusinessRepository());
        }     
    }
