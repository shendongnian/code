    public override async Task OnDisconnectedAsync(Exception exception)
        {
            var itemToRemove = ConnectedUsers.Single(r => r.ID == Context.ConnectionId);
            ConnectedUsers.Remove(itemToRemove);
    
            await Clients.Others.SendAsync("update", itemToRemove.Name + " has left the server.");
            await Clients.All.SendAsync("update-people", JsonConvert.SerializeObject(ConnectedUsers));
            return base.OnDisconnectedAsync(exception);
        }
