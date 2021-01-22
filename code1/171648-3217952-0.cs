    void ProcessConnection(TcpClient client)
    {
        bool lockTaken = false;
    
        Monitor.TryEnter(MyCriticalSectionObject, out lockTaken);
    
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
            Monitor.Exit(MyCriticalSectionObject);
            client.Close();
        }
    }
