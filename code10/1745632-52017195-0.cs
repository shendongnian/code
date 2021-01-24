    public class PresenceHub : Hub
  {
    //Members
    private IPbxConnection _connection; 
    /// <summary>
    /// Constructor, pbx connection must be provided by dependency injection
    /// </summary>        
    public PresenceHub(IPbxConnection connection)
    {
        _connection = connection;
        _connection.OnUserUpdated((e) =>
        {                
            Clients.All.SendAsync("UpdateUser", "updateuserobject");
        });
        _connection.Connect();
    }
    /// <summary>
    /// Called whenever a user is connected to the hub. We will send him all the user information
    /// </summary>
    public override async Task OnConnectedAsync()
    {            
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("AddUser", "userobject");
    }
