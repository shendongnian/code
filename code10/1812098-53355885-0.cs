    var commands = new Dictionary<string, Action<string[]>>
    {
        ["ban"] = HandleBanCommand,
    };
    
    var args = e.PrivateMessage.Split(' ');
    if (args[0].StartsWith("."))
    {
        if (commands.TryGetValue(args[0].Substring(1), out var command))
        {
            command(args);
        }
        else
        {
            // command not found...
        }
    }
    
    // ...
    
    void HandleBanCommand(string[] args)
    {
        if (args.Length < 3)
        {
            // arguments missing...
            return;
        }
    
        var user = args[1];
        var reason = args[2];
        // add duration, and increment the length above by 1
    
        // ban the user...
    }
