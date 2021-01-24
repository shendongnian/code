            Log.Logger = new LoggerConfiguration()
              .Enrich.With<HttpRequestIdEnricher>()
              .Enrich.With<HttpRequestNumberEnricher>()
              .Enrich.With<HttpSessionIdEnricher>()
              .Enrich.With<HttpRequestTraceIdEnricher>()
              .WriteTo.Debug()
              .CreateLogger();
