    public class SignalHub : Hub
    {
        
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
