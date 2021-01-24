    public static class LogContext
    {
    	public static ILogEventEnricher Clone();
    	public static IDisposable Push(ILogEventEnricher enricher);
    	public static IDisposable Push(params ILogEventEnricher[] enrichers);
        [Obsolete("Please use `LogContext.Push(properties)` instead.")]
        public static IDisposable PushProperties(params ILogEventEnricher[] properties);
    	public static IDisposable PushProperty(string name, object value, bool destructureObjects = false);
    }
