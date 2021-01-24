    public async Task SendMessage(Msg model)
    {
        await StartIfNeededAsync();
        await _connection.SendAsync("Send", model);
    }
