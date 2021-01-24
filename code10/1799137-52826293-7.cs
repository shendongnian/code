    public class MyClass
    {
        private readonly IHubContext<MyHub, ITypedHubClient> _hubContext;
    
        public MyClass(IHubContext<MyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }
    
        public void InitializeServers()
        {
            foreach(/* server I have in database */)
            {
                ServerStatus s = new ServerStatus(_hubContext, ...);
            }
        }
    }
