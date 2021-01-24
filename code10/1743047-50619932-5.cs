    public class MessageHub : Hub
    {
		public async Task SendMessage(string title, string user, string message)
		{
			await Clients.All.SendAsync("SendMessageToClient", title, user, message);
		}
	}
