    public override Task OnDisconnectedAsync(Exception exception)
    {
        this.hubConnectionService.RemoveConnection(this.Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
