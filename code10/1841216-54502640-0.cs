    private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    public async Task SendAsync(string message)
    {
        if (_ws.State != WebSocketState.Open)
            throw new Exception("Connection is not open");
        try
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            var cancel = new CancellationTokenSource(5000);
            var bytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await _ws.SendAsync(bytes, WebSocketMessageType.Text, true, cancel.Token).ConfigureAwait(false);
        }
        finally
        {
            _semaphore.Release();
        }
    }
