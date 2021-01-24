    public class YourBackgroundService : IHostedService
    {
        private Server _server;
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _server = new Server
            {
                Services = {ConnectionHandler.BindService(_vpnConnectionHandler)},
                Ports = {new ServerPort("0.0.0.0", 50055, ServerCredentials.Insecure)}
            };
            _server.Start();
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return server?.ShutdownAsync() ?? Task.CompletedTask;
        }
    }
