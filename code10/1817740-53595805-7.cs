    public class MyService: IHostedService, IDisposable
       {
           private readonly ILogger _logger;
           private readonly Daemon _deamon;
    
           public MyService(ILogger<MyService> logger, Daemon daemon /* and probably the rest of dependencies*/)
           {
               _logger = logger;         
               _daemon = daemon;  
           }
    
           public async Task StartAsync(CancellationToken cancellationToken)
           {
               await _deamon.StartAsync(cancellationToken);
           }
    
           public async Task StopAsync(CancellationToken cancellationToken)
           {
               await _deamon.StopAsync(cancellationToken);
           }
    
           public void Dispose()
           {
               _deamon.Dispose();
           }
    }
