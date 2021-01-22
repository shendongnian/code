    public class ServiceProvider : IServiceProvider
    {
        ...
    }
    public class ConnectionViewModel 
    {
        private IServiceProvider serviceProvider;
    
        public ConnectionViewModel(IServiceProvider provider)
        {
            this.serviceProvider = serviceProvider;
        }
    
        ...       
    }
