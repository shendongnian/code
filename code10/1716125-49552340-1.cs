    public static LoggerConfiguration WithCorrelationIds(
        this LoggerEnrichmentConfiguration enrichmentConfiguration,
        ICorrelationContextProvider provider)
    {
        return enrichmentConfiguration.With(new CorrelationIdsEnricher(provider));
    }
