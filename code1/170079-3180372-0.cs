    private static void ConnectSessionManager<T>(T service)
    {
         SessionManager<T>.Current.Connect(service)
    }
    protected void ProcessInboundMessage()
    {
        // Connect
        ConnectSessionManager(this);
    }
