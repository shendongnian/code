    int attempts = 0;
    do
    {
        try
        {
            client.Connect();
        }
        catch (Renci.SshNet.Common.SshConnectionException e)
        {
            attempts++;
        }
    } while (attempts < _connectiontRetryAttempts && !client.IsConnected);
