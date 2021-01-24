    public string BroadcastMessage() {
       IHubContext context = GlobalHost.ConnectionManager.GetHubContext<myHub>();
       context.Clients.All.showMessage("ABC");
       return "Hello World";
    }
