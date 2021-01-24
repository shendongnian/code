    public class MyClass
    {
        private readonly IServiceProvider _provider;
        public MyClass(IServiceProvider provider)
        {
            _provider = provider;
        }
        public void InitializeServers()
        {
            foreach(/* server I have in database */)
            {
                var hub = _provider.GetService<IHubContext<MyHub, ITypedHubClient>>();
                ServerStatus s = new ServerStatus(hub, ...);
            }
        }
    }
