    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Maps SignalR hubs to the app builder pipeline at "/signalr".
            app.MapSignalR();
        }
    }
