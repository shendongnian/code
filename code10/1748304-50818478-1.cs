    namespace SmithWindowsService 
    {    
        public partial class SmithWindowsService : ServiceBase 
        {
            private ServiceHost host;
    
            public SmithWindowsService( ) 
            {
                InitializeComponent( );
            }
    
            protected override void OnStart(string[] args) 
            {
                var instance = new SmithWcfService.SmithWcfService(this.SomeMethodYouWantToCallIn);
                host = new ServiceHost(instance, new Uri("your.url.com"));
                host.Open( );
            } 
            
            private int SomeMethodYouWantToCall(string data)
            {
                // do things...
            }
        }
    }
