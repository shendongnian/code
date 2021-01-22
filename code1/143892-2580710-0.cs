    ConnectSession session = new ConnectSession(API_KEY, API_SECRET);
    Api api = new Api(session);
                
    if (session.IsConnected())
    {
        // User is authenticated
    }
