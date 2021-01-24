    public async Task CheckAllMessages()
    {
        foreach (var user in ConnectedUsers)
        {
           var nr = GetNrOfMessagesForUser(user);
           if(nr > 0)
           {
               await Clients.User(user)
                            .SendAsync("ReceiveMessage", 
                                       $"User ({user}) has {nr} new messages waiting.");
           }
        }
    }
