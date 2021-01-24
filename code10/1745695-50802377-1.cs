        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry("ikey"); /* This enables entire application insights auto-collection. If you don't want anything but the traces, then ikey can be set in TelemetryConfiguration.Active.InstrumentationKey as the above console app example. */
            services.AddMvc();
            Trace.Listeners.Add(new ApplicationInsightsTraceListener());
        }
