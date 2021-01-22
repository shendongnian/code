    void ProcessConnection(TcpClient client)
    {
        bool lockTaken = false;
    
        Monitor.TryEnter(lockObject, out lockTaken);
    
        if (!lockTaken)
        {
            client.Close();
            return;
        }
    
        try
        {
            // long-running process here
        }
        finally
        {
            Monitor.Exit(lockObject);
            client.Close();
        }
    }
