        public class HostServiceHelper : IHostedService
        {
            private static IHubContext<EngineHub> _hubContext;
    
            public HostServiceHelper(IHubContext<EngineHub> hubContext)
            {
                _hubContext = hubContext;
            }
    
            public Task StartAsync(CancellationToken cancellationToken)
            {
                return Task.Run(() =>
                {
                    Task.Run(() => ServiceWebSocket(), cancellationToken);
    
                    Task.Run(() => ServiceBox(), cancellationToken);
    
                    Task.Run(() => ServiceLogging(), cancellationToken);
    
                }, cancellationToken);
            }
    
            public void ServiceLogging()
            {
            // your own CODE
             }
    
            public void ServiceWebSocket()
            {
     // your own CODE
            }
    
            public void ServiceBox()
            {
                // your own CODE
            }
    
            public Task StopAsync(CancellationToken cancellationToken)
            {
                //Your logical
                throw new NotImplementedException();
            }
        }
