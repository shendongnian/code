    using System.ServiceProcess;
    using Hangfire;
    using Hangfire.SqlServer;
    
    namespace WindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            private BackgroundJobServer _server;
    
            public Service1()
            {
                InitializeComponent();
    
                GlobalConfiguration.Configuration.UseSqlServerStorage("connection_string");
            }
    
            protected override void OnStart(string[] args)
            {
                _server = new BackgroundJobServer();
            }
    
            protected override void OnStop()
            {
                _server.Dispose();
            }
        }
    }
