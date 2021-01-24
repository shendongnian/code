    public class HubEventEmitter
    {
        private IHubContext<PresenceHub> _hubContext;
        public HubEventEmitter(IPbxConnection connection, IHubContext<PresenceHub> hubContext)
        {
            _hubContext = hubContext;
            _connection.OnUserUpdated((e) =>
            {
                _hubContext.Clients.All.SendAsync("UpdateUser", "updateuserobject");
            });
        }
    }
