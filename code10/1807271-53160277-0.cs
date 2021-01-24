    public class ProxyLogger : ILogger
    {
        public ILogger Logger { get; set; }
        public void Log<TState>(LogLevel l, EventId id, TState s, Exception ex,
           Func<TState,Exception,String> f) =>
           this.Logger.Log<TState>(l, id, s, ex, f);
        // Implement other functions
    }
