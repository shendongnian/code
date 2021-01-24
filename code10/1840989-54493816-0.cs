    using Serilog;
    using Serilog.Core;
    using Serilog.Events;
    
    public void Configure(IApplicationBuilder app,
                          IHostingEnvironment env,
                          ILoggerFactory loggerFactory)
    {
        loggerFactory.AddSerilog(
            new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Sink(new LogEventSink())
                .CreateLogger());
    }
    public class LogEventSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            string message = logEvent.RenderMessage();
            // Write to my log.
        }
    }
