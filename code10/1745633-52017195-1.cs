    public class PresenceHub : Hub
    {
		public async Task Send(Tick tick)
        {
            await Clients.Others.SendAsync("Send", tick);
        }
   
		public override async Task OnConnectedAsync()
		{            
			await base.OnConnectedAsync();
			await Clients.Caller.SendAsync("AddUser", "userobject");
		}
	}
	
