    [Command("Help")]
    public async Task Help()
    {
        List<CommandInfo> commands = _commandService.Commands.ToList();
        EmbedBuilder embedBuilder = new EmbedBuilder();
    
        foreach (CommandInfo command in commands)
        {
            // Get the command Summary attribute information
            string embedFieldText = command.Summary ?? "No description available\n";
    
            embedBuilder.AddField(command.Name, embedFieldText);
        }
    
        await ReplyAsync("Here's a list of commands and their description: ", false, embedBuilder.Build());
    }
