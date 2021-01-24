    // Not hub method
    public async Task Send(string message)
    {
        await _chatHubContext.Clients.All.SendAsync("SendMessage", message);
    }
