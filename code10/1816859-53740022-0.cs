    public partial class YourWindowsService : ServiceBase
    {
        // It's your choice where to create this instance, I used constructor injection here arbitrarily
        private readonly YourWCFServiceFactory serviceFactory;   
      
        private ServiceHost host;
        public YourWindowsService(YourWCFServiceFactory serviceFactory)
        {
            InitializeComponent();
            this.serviceFactory = serviceFactory;
        }
        protected override void OnStart(string[] args)
        {
            Type serviceType = typeof(YourService);
            host = serviceFactory.CreateServiceHost(serviceType, new string[] { "yourBaseUri" });
            host.Open();
        }
        protected override void OnStop()
        {
            if(host != null)
               host.Close();
        }
    }
    
