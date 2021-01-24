    public class NotifyService
    {
        private readonly IHubContext<ChatHub> _hub;
    
        public NotifyService(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
    
        public Task SendNotificationAsync(string message)
        {
            return _hub.Clients.All.InvokeAsync("ReceiveMessage", message);
        }
    }
