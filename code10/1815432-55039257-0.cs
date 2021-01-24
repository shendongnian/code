    ...
    using Microsoft.Extensions.Hosting;
    ...
	public class HostedTcpIpService : IHostedService, IDisposable
    {
        #region Declaration(s)
        private readonly ILogger<HostedTcpIpService> logger;
        private readonly IHubContext<VcHub> hubContext;
        #endregion
        #region Constructor
        public HostedTcpIpService(
            ILogger<HostedTcpIpService> logger,
            IHubContext<VcHub> hubContext)
        {
            this.logger = logger;
            this.hubContext = hubContext;
        } 
        #endregion
        #region IDisposable
        public void Dispose()
        {
            // disposing
        } 
        #endregion
        #region IHostedService
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Start Tcp connection
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop Tcp connection
        }
        #endregion
		
		private void OnTcpMessageReceived(string tcpMessage) 
		{
            // injected hubContext ...
			// broadcast to signalR clients
			this.hubContext.Clients.All.SendAsync("broadcastMessage", tcpMessage);
		}
	}
