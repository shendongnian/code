    Log.Logger = new LoggerConfiguration()
        .Enrich.WithExceptionDetails()
        .Enrich.FromLogContext()
        .MinimumLevel.Warning()
        .WriteToConsoleIfEnabled()  // <---
        .WriteToFileIfEnabled()     // <---
        .CreateLogger();
