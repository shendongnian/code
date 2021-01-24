    var socketUserMessage = message as SocketUserMessage;
    if(socketUserMessage == null) return; // do some error handling
    
    foreach (string badWord in File.ReadLines(@"bannedwords.txt"))
    {
        if (e.Content.Contains(badWord))
        {
            await ReplyAsync($"{user.Mention} Dont mention that in here");
        }
    }
