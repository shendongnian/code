    var config = new JobHostConfiguration();
    
    if (config.IsDevelopment)
    {
         config.UseDevelopmentSettings();
    }
    config.UseTimers();
    config.DashboardConnectionString ="storage connectionstring";
    config.StorageConnectionString = "storage connectionstring";
    var host = new JobHost(config);
    host.RunAndBlock();
    
