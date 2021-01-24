    public async Task SubscribeToGameChanges(long id)
    {
        await this.Groups.AddToGroupAsync(this.Context.ConnectionId, Helper.GetGameGroupName(id));
    }
    
