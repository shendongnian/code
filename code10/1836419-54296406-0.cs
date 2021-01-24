    [ServiceContract(Namespace = "http://my.super.original.namespace")]
    public interface IWCFService
    {
        [OperationContract, WebGet]
        Stream GetJSON();
    }
    //Decorator goes on WCF service, not the Windows service
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyWCFService : IWCFService
    {
        private StateObject _myStateObject;
        public MyWCFService()
        {
            _myStateObject = new StateObject();
            _myStateObject.Init();
        }
        public Stream GetJSON()
        {
			.
			.
			.
            return "JSON String Here";
        }
    }
    public class MyWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        private readonly MyWcfService _wcfSingleton;
        public MyWindowsService()
        {
            ServiceName = "WindowsServiceNameHere";
            _wcfSingleton = new MyWCFService();
        }
        public static void Main()
        {
            ServiceBase.Run(new MyWindowsService());
        }
        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            //load WCF Singleton Instance and open it for connections
            serviceHost = new ServiceHost(_wcfSingleton);
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
