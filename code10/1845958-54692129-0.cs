    public async Task JoinGroup(string name, string group)
    {
        await Groups.Add(Context.ConnectionId, group);
    }
    
    public Task LeaveGroup(string name, string group)
    {
        return Groups.Remove(Context.ConnectionId, group);
    }
    
