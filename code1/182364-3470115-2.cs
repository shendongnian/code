    [ServiceContract]
    interface IMyService { ... }
    
    interface IMyServiceFascade : IMyService { ... }
    
    // dummy fascade
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall]
    public class MyServiceFascade : IMyServiceFascade 
    { 
        private static IMyService _serviceInstance = new MyService();
    
        public static IMyService ServiceInstance { get { return _serviceInstance; } }
    
        public int MyMethod()
        {
           return _serviceInstance.MyMethod();
        }
        ... 
    }
    
    // the logic class that does the work
    public class MyService : IMyService { ... }
    
    // then host the fascade
    var host = new ServiceHost(typeof(MyServiceFascade));
    
    // but you can still access the actual service class
    var serviceInstance = MyServiceFascade.ServiceInstance;
