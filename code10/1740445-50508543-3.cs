    public HubUtil(string baseUrl) {
        connection = new HubConnectionBuilder()
            .AddJsonProtocol()
            .WithUrl(baseUrl)  // baseUrl is "https://hostname/hubname"
            .Build();
        connection.Closed += Connection_Closed;       
    }
    private Task Connection_Closed(Exception arg) {
        return StartIfNeededAsync();
    }
    public async Task StartIfNeededAsync() {
        if (_connectionState == ConnectionState.Connected) {
            return;
        }
        try {
            await connection.StartAsync();
            _connectionState = ConnectionState.Connected;
        } catch (Exception ex) {
            _connectionState = ConnectionState.Faulted;
            throw;
        }
    }
    //...
