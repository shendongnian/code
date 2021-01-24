    [HubName("MyHub")]
    public class MyHub : Hub
    {
        public void logout()
        {
            var connectionId = Context.ConnectionId;
            // notify all users
            Clients.All.broadcastMessage($"User {connectionId} has left!");
            // private message to caller
            Clients.Caller.goodbye();
        }
