    public override Task OnDisconnectedAsync(Exception exception)
        {
            var itemToRemove = ConnectedUsers.Single(r => r.ID == Context.ConnectionId);
            ConnectedUsers.Remove(itemToRemove);
    
            Clients.Others.SendAsync("update", itemToRemove.Name + " has left the server.");
            Clients.All.SendAsync("update-people", JsonConvert.SerializeObject(ConnectedUsers));
            return base.OnDisconnectedAsync(exception);
        }
