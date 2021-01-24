    using System;
    namespace Demo
    {
        class Program
        {
            public static void Main(string[] args)
            {
                var coreContext = new CoreContext(context => new ClientSocketHandler(context))
                {
                    ConfigHandler = new ConfigHandler()
                };
            }
            class ConfigHandler {}
            class ClientSocketHandler
            {
                readonly CoreContext _coreContext;
                public ClientSocketHandler(CoreContext coreContext)
                {
                    _coreContext = coreContext;
                }
            }
            class CoreContext
            {
                public CoreContext(Func<CoreContext, ClientSocketHandler> socketHandlerFactory)
                {
                    SocketHandler = socketHandlerFactory(this);
                }
                public ClientSocketHandler SocketHandler { get; private set; }
                public ConfigHandler ConfigHandler { get; set; }
            }
        }
    }
