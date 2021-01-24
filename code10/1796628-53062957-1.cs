    // This provides strongly-typed methods that you'll have on the Client side but these don't exist on the server.
    public interface IChatClient
    {
        //So this method is a JS one not a .net one and will be called on the client(s)
        Task DoSomething(int id);
        Task NotificationUpdate(int id, string message);
    }
