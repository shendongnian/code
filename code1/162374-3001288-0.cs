    public bool TryConnect(string connectionString, out ConnectionStatus status)
    {
        ... try to connect
        ... set status, and return true/false
    }
    public void Connect(string connectionString)
    {
        ConnectionStatus status;
        if (!TryConnect(connectionString, out status))
            switch (status)
            {
                case ConnectionStatus.HostNotFound:
                    throw new HostNameNotFoundException();
                ...
            }
    }
