    public class PresenceHub : Hub
    {
		public async Task Send(Userobject userobject)
        {
            await Clients.Others.SendAsync("AddUser", userobject);
        }
   
		public override async Task OnConnectedAsync()
		{            
			await base.OnConnectedAsync();
			await Clients.Caller.SendAsync("AddUser", "userobject");
		}
	}
	
