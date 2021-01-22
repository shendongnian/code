    AutoResetEvent clientDataSent = new AutoResetEvent(true);
    
    public void Write(byte[] data)
    {
        // Wait till the Write operation gets a green light to proceed. Consider using a timeout.
        clientDataSent.WaitOne();
        clientArgs.SetBuffer(data, 0, data.Length);
        bool willRaiseEvent = client.SendAsync(clientArgs);
        // Write operation will get a signal either from ProcessSend (sync) or clientArgs_Completed (async),
        if (!willRaiseEvent) ProcessSend(clientArgs);
    }
    
    void clientArgs_Completed(object sender, SocketAsyncEventArgs e)
    {
        bool throwInvalidOperationException = false;
        switch (e.LastOperation)
        {
            ...
            default:
                throwInvalidOperationException = true;
        }
        //Signal a waiting Write operation that it can proceed.
        clientDataSent.Set();
        if (throwInvalidOperationException) throw new Exception("Invalid operation completed");
    }
