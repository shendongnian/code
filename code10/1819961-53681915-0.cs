    public class MessageHub : Hub
    {
        public Task Send(string user ,string message)
        {
            return Clients.All.SendAsync("Send", user, message);
        }
    
        public Task MyMethod(string parameter)
        {
            //do something here
        }
    }
