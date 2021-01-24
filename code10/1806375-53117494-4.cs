    private readonly Timer _timer;
    private readonly HttpClient _client;
    
    public Pinger(HttpClient client)
    {
        _client = new HttpClient();
        _timer = new Timer(Heartbeat, null, 1000, 1000);
    }
    public void Heartbeat(object state)
    {
        // Discard the result
        _ = DoAsyncPing();
    }
    private async Task DoAsyncPing()
    {
        await _client.GetAsync("http://mybackend/api/ping");
    }
