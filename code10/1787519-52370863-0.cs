    public MyClient(HttpMessageHandler handler) : base(handler)
    {
        Handler = handler;
    }
    
    public MyClient(HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler )
        Handler = handler;
    )
    
    public HttpMessageHandler Handler { get; }
