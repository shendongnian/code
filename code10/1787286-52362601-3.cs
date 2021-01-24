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
                // you may also check the exception for what happened exactly.
                // There may be conditions where retrying does not make sense.
                // See SocketException.ErrorCode
            }
            else
            {
                // You may want to handle exceeding max tries.
                // - Notify User
                // - Maybe throw a custom exception
            }
        }
    }
