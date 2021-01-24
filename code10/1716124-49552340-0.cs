    using Common.Correlation;
    using Serilog.Core;
    using Serilog.Events;
    
    namespace Common.Logging.Enrichers
    {
        public class CorrelationIdsEnricher : ILogEventEnricher
        {
            private readonly ICorrelationContextProvider _provider;
    
            public CorrelationIdsEnricher(ICorrelationContextProvider provider)
            {
                _provider = provider;
            }
    
            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                var (requestId, correlationId) = GetIds();
                logEvent.AddPropertyIfAbsent(
                    propertyFactory.CreateProperty("RequestId", requestId, false));
                logEvent.AddPropertyIfAbsent(
                    propertyFactory.CreateProperty("CorrelationId", correlationId, false));
            }
    
            private (string requestId, string correlationId) GetIds()
            {
                var ctx = _provider.Context;
                return (ctx?.RequestId ?? string.Empty, ctx?.CorrelationId ?? string.Empty);
            }
        }
    }
