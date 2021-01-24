    private void GetConnection()
        {
            if (!_transport.IsConnected)
            {
                _transport.GetConnection(_host, _port);
            }
        }
