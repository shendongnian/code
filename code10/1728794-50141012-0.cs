    var options = new BackgroundJobServerOptions
    {
        WorkerCount = 1,
        ServerName = "removeMe",
    };
    // ....
    IMonitoringApi monitoringApi = JobStorage.Current.GetMonitoringApi();
    var serverToRemove = monitoringApi.Servers().First(svr => srv.Name.Contains("removeMe"));
    JobStorage.Current.GetConnection().RemoveServer(serverToRemove.Name);
