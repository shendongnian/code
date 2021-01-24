    public async Task StartIfNeededAsync()
    {
        if (_connectionState == ConnectionState.Connected)
        {
            return;
        }
        try
        {
            await connection.StartAsync();
            _connectionState = ConnectionState.Connected;
        }
        catch (Exception ex)
        {
            _connectionState = ConnectionState.Faulted;
            throw;
        }
    }
