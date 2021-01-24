    BackgroundJob.Schedule<IHubContext<MySignalRHub>>(hubContext => 
        hubContext.Clients.All.SendAsync(
            "MyMessage",
            "MyMessageContent", 
            System.Threading.CancellationToken.None), 
        TimeSpan.FromMinutes(2));
