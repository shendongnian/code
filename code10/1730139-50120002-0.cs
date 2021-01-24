    public class MyService : IMyService
    {
        public MyService(IService1 service1, IService2 service2, IOptions<MyServiceOptions> serviceOptions)
        {
            var connectionString = serviceOptions.Value.ConnectionString;
            //...
        }
    }
    public class MyServiceOptions
    {
        public string ConnectionString
        { get; set; }
    }
