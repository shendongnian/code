    [Command("random")]
    public async Task random([Remainder]string message)
    {
        var embed = new EmbedBuilder();
        if (String.IsNullOrEmpty(message))
        {
            embed.WithDescription("Example: $random option1|option2|option3");
            // miss return proecess? 
        }
        string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        Random randNr = new Random();
        string slection = options[randNr.Next(0, options.Length)];
        embed.WithTitle("Choise for " + Context.User.Username);
        embed.WithDescription(slection);
        embed.WithColor(new Color(Color.DarkGreen.RawValue));
        await Context.Channel.SendMessageAsync("", false, embed);
    }
