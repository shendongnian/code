    using System.Memory;
    public delegate Span<byte> SpanFactoryFunc();
    
    public Span<byte> CallSpanFactory(SpanFactoryFunc spanFactory)
    {
        return spanFactory();
    }
