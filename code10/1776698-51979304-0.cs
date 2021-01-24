    public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
    
                StorageCredentials credentials = new StorageCredentials("your storage account", "your key");
                CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, false);
    
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Trace(Serilog.Events.LogEventLevel.Information)
                    .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
                    .WriteTo.RollingFile(@"your file path", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level}:{EventId} [{SourceContext}] {Message}{NewLine}{Exception}")
                    .WriteTo.RollingAzureBlobSink(null, storageAccount, "testyy", "jj", 5, TimeSpan.FromMinutes(3))
                    .CreateLogger();
    
                Log.Debug("a good thing debug");
                Log.Information("a info inforxxxxx");
            }
