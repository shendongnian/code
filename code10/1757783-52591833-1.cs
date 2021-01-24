    using Serilog;
    ...
    public void ConfigureServices( IServiceCollection services )
    {
        ...
 
        ICustomLogger customLogger = new CustomLogger( new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.RollingFile( @"Logs\CustomLog.{Date}.log", retainedFileCountLimit: 7 )
            .CreateLogger() );
        services.AddSingleton( customLogger );
         
        ...
    }
