    using System.ServiceProcess;
    namespace WindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            readonly Runner _runner = new Runner();
            static void Main(string[] args)
            {
                var service = new Service1();
                if (Debugger.IsAttached)
                {
                    service.OnStart(args);
                    Console.WriteLine("Find the any key!");
                    Console.Read();
                    service.OnStop();
                }
                else
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        service
                    };
                    ServiceBase.Run(ServicesToRun);
                }
            }
            public Service1()
            {
                InitializeComponent();
            }
            protected override void OnStart(string[] args)
            {
                _runner.Run();
            }
            protected override void OnStop()
            {
                _runner.Stop();
            }
        }
    }
