    [HubName("MyHub")]
    public class MyHub : Hub
    {
        public void logout()
        {
            Clients.Caller.clientLogout();
        }
    }
