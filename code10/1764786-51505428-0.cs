            var loggerConfiguration = new LoggerConfiguration()
                           .MinimumLevel.Verbose()
                           .Enrich.FromLogContext();
            var fileBasePath = "<base log path>";
            loggerConfiguration
                .WriteTo.Console()
                .WriteTo.RollingFile(fileBasePath + "log-info-{Date}.txt")
                .WriteTo.Logger(fileLogger => fileLogger
                        .MinimumLevel.Error()
                        .WriteTo.RollingFile(fileBasePath + "log-error-{Date}.txt"))
                .WriteTo.Logger(fileLogger => fileLogger
                        .Filter.ByIncludingOnly(x =>
                              x.Level == LogEventLevel.Information &&
                              x.Properties.ContainsKey("<Audit Key>"))
                        .WriteTo.RollingFile(fileBasePath + "log-audit-{Date}.txt"));
            Log.Logger = loggerConfiguration.CreateLogger();
