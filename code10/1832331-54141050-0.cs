    private Task OnMessageDeleted(Cacheable<IMessage, ulong> msg, ISocketMessageChannel channel)
    {
        Console.WriteLine(msg.HasValue ? 
            msg.Value.Content : 
            "A message was deleted, but its content could not be retrieved from cache.");
        return Task.CompletedTask;
    }
