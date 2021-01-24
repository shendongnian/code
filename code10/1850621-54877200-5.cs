    public void Configure(IWebJobsBuilder webJobsBuilder) {       
    
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
