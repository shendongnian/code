    public class MessageHub : Hub<ITypedHubClient>
    {
		public async Task SendMessage(string title, string user, string message)
		{
			await Clients.All.SendMessageToClient(title, user, message);
		}
	}
	public interface ITypedHubClient
	{
		Task SendMessageToClient(string title, string name, string message);
	}
