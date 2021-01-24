    public class Daemon: IDisposable
       {
           private ILogger<Daemon> _logger;
    		
          
           protected TaskRunnerBase(ILogger<Daemon> logger)
           {
              _logger = logger;
           }
    		
           public async Task StartAsync(CancellationToken cancellationToken)
           {            
               while (!cancellationToken.IsCancellationRequested)
               {
    				await MainAction.DoAsync(cancellationToken); // main job 
    			}
           }
    
           public async Task StopAsync(CancellationToken cancellationToken)
           {
               await Task.WhenAny(MainAction, Task.Delay(-1, cancellationToken));
               cancellationToken.ThrowIfCancellationRequested();
           }
    
           public void Dispose()
           {
                MainAction.Dispose();
           }
    }
