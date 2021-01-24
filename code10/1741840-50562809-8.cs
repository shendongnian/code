        public Task Run(IProgress<MonitorDTO> progress,CancellationToken ct)
        {
          while(!ct.IsCancellationRequested)
          {
            //...
          }
        }
    public static async Task Maim()
    {
        var ulrs=new[]{....};
        var monitor=new MyMonitor(urls);
        var progress=new Progress<MonitorDTO>(pg=>{
             Console.WriteLine($"{pg.Success} for {pg.Url}: {pg.Message}");
        });
        var cts = new CancellationTokenSource();
        //Not awaiting yet!
        var monitorTask=monitor.Run(progress,cts.Token);
        //Keep running until the first keypress
        Console.ReadKey();
        //Cancel and wait for the monitoring class to gracefully stop
        cts.Cancel();        
        await monitorTask;
