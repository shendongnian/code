    // In Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(IUserService, UserServiceA);
        services.AddScoped(IUserService, UserServiceB);
        services.AddScoped(IUserService, UserServiceC);
    }
    // Any class that uses the service(s)
    public class Consumer
    {
        private readonly IEnumerable<IUserService> _myServices;
        
        public Consumer(IEnumerable<IUserService> myServices)
        {
            _myServices = myServices;
        }
        public UserServiceA()
        {
            var userServiceA = _myServices.FirstOrDefault(t => t.GetType() == typeof(UserServiceA));
            userServiceA.DoTheThing();
        }
        public UserServiceB()
        {
            var userServiceB = _myServices.FirstOrDefault(t => t.GetType() == typeof(UserServiceB));
            userServiceB.DoTheThing();
        }
        public UseServiceC()
        {
            var userServiceC = _myServices.FirstOrDefault(t => t.GetType() == typeof(UserServiceC));
            userServiceC.DoTheThing();
        }
    }
