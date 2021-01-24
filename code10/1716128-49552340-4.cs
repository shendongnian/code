    public class CorrelationContextProvider : ICorrelationContextProvider
    {
        public static ICorrelationContextProvider Default { get; } = new CorrelationContextProvider();
        public ICorrelationContext Context => new CorrelationContext();
    }
