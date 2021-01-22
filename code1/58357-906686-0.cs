    namespace WindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            internal static ServiceHost myServiceHost = null;
    
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                if (myServiceHost != null)
                {
                    myServiceHost.Close();
                }
                myServiceHost = new ServiceHost(typeof(WcfServiceLibrary1.Service1));
                myServiceHost.Open();
            }
    
            protected override void OnStop()
            {
                if (myServiceHost != null)
                {
                    myServiceHost.Close();
                    myServiceHost = null;
                }
            }
        }
    }
