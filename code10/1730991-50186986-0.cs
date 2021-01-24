    public class EventHub : Hub
    
        {
            public void LogOutSignalRTest()
            {
    
                var cc = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<EventsHub>();
                    cc.Clients.Client(Context.ConnectionId).clientlogout();
    
            }
        }
