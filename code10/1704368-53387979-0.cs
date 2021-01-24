    public class DependencyManager{
        static class IServiceProvider ServiceProvider{ get;set;}
    }
    public class SomeMiddleware{
        public void SomeMethod(){
             var someServiceInstance = DependencyManager.ServiceProvider.GetService<SomeService>();
        }
    }
