    // This class is used by the JavaScript Client to call into the .net core application.
    public class ChatHub : Hub<IChatClient>
    {
        public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();
        // As an example, On connection save the user name with a link to the client Id for later user callback
        public override Task OnConnectedAsync()
        {
            var user = Context.User.Identity.Name;
            
            Connections.AddOrUpdate(this.Context.ConnectionId, user, (key, oldValue) => user);
            
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            // Do something on disconnect.
        }
        // Add other methods you want to be able to call from JavaScript side in here...
        public void SendMessage(int id, string message)
        {
            // Message doing stuff here.
        }
    }
