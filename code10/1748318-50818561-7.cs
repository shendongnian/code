    Callbacks2 callbacks = GetServerPluginInterface();
    callbacks.RemoteConnectionRequest = RemoteConnectionRequestTest;
    callbacks.StartServer();
    while (true)
    {
    }
