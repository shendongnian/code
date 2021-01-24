    public void Configure(IWebJobsBuilder webJobsBuilder) {
        webJobsBuilder.AddDependencyInjection();
    
        //  ** Registers the ILogger instance **
        webJobsBuilder.Services.AddLogging();
    
        //OR
        //webJobsBuilder.Services.AddLogging(builder => {
        //    //...
        //});
    
        //  Registers the application settings' class.
        //...
        //...removed for brevity
    }
