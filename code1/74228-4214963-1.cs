    private void OnAccept(IAsyncResult pAsyncResult)
    {
        TcpListener listener = (TcpListener) pAsyncResult.AsyncState;
        if(listener.Server == null)
        {
            //stop method was called
            return;
        }
        ...
    }
