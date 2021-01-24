    public class NotificationService
    {
        private readonly IHubContext<MyHub> _myHubContext;
        public NotificationService(IHubContext<MyHub> myHubContext)
        {
            _myHubContext= myHubContext;
        }
  
        public async Task SendMessage(string message)
        {
            await _myHubContext.Clients.All.SendAsync("Update", message);
        }      
    }
