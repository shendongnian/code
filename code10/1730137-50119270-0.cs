    public class MyService : IMyService {
        private string connectionString;
        public MyService(IService1 service1, IService2 service2, IOptions<MyConnections> options){
            connectionString = options.Value.MyConnectionString;
            //...
        }
        
        //...
    }
    
