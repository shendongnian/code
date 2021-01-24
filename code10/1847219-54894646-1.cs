    public class NotificationHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("Notification", message);
        }
    }
