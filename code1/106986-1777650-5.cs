    using System.ServiceModel;
    using System.ServiceProcess;
    using AdditionServiceNamespace;
    namespace WindowsServiceNamespace
    {
        public class WindowsService : ServiceBase
        {
            static void Main()
            {
                ServiceBase[] ServicesToRun = new ServiceBase[]
                { new WindowsService() };
                ServiceBase.Run(ServicesToRun);
            }
            private ServiceHost _host;
            public WindowsService()
            {
                InitializeComponent();
            }
            protected override void OnStart(string[] args)
            {
                _host = new ServiceHost(typeof(AdditionService));
                _host.Open();
            }
            protected override void OnStop()
            {
                try
                {
                    if (_host.State != CommunicationState.Closed)
                    {
                        _host.Close();
                    }
                }
                catch
                {
                    // handle exception somehow...log to event viewer, for example
                }
            }
        }
    }
