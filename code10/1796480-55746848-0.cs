protected async override Task ExecuteAsync(CancellationToken stoppingToken)
{            
    while (!stoppingToken.IsCancellationRequested)
    {
        // Do something nice here
        await Task.Delay(2000);
    }
}   
