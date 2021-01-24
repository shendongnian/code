    public static ILogEventEnricher Clone()
    {
        var stack = GetOrCreateEnricherStack();
        return new SafeAggregateEnricher(stack);
    }
