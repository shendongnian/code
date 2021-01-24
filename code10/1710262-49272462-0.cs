    public static void Wrapper(ClientContext clientContext, SPRemoteEventProperties properties, Action<ClientContext, SPRemoteEventProperties> action)
    {
        action(newClientContext, properties);
    }
    ...
    Wrapper( new ClientContext(), new SPRemoteEventProperties(),(context, properties) => Console.WriteLine("Function1: " + context.i));
