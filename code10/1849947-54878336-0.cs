    var configuration = new LoggerConfiguration()
          .ReadFrom.AppSettings()
          .Enrich.FromLogContext()
          .Enrich.WithMachineName()
          .Enrich.WithProcessId()
          .Enrich.WithThreadId();
    if (isElasticSinkEnabled)
        configuration.WriteTo.ElasticsearchIfEnabled();
    var logger = Log.Logger = configuration.WriteTo.Async(
              a => a.File(
                  filePath,
                  outputTemplate: CanonicalTemplate,
                  retainedFileCountLimit: 31,
                  rollingInterval: RollingInterval.Day,
                  rollOnFileSizeLimit: true,
                  buffered: true,
                  flushToDiskInterval: TimeSpan.FromMilliseconds(500)))
        .CreateLogger();
