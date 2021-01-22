    private void OnRecieve(IAsyncResult parameter) 
    {
        Socket sock = (Socket)parameter.AsyncState;
        if(!sock.Connected || sock.Available == 0)
        {
            // Connection is terminated, either by force or willingly
            return;
        }
        sock.EndReceive(parameter);
        sock.BeginReceive(..., ... , ... , ..., new AsyncCallback(OnRecieve), sock);
        // To handle further commands sent by client.
        // "..." zones might change in your code.
    }
