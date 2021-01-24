    private void ConnectCallback(IAsyncResult ar)
    {
        ConnectionState state = (ConnectionState)ar.AsyncState;
        try
        {
            state.Client.EndConnect(ar);
        }
        catch (SocketException ex)
        {
            _logger.Info(ex.ToString());
            if( state.FailedAttempts < MAX_ATTEMPTS )
            {
                state.FailedAttempts += 1;
                state.Client.BeginConnect( remoteEP, new AsyncCallback(ConnectCallback), state );
            }
            else
            {
                // You may want to handle exceeding max tries.
                // - Notify User
                // - Maybe throw a custom exception
            }
        }
    }
