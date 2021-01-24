    [Command("buy")]
    public async Task Buy(string item)
    {
        if (item == "" || item == "" || item == "" || item == "" || item == "⛏")
        {
            await ReplyAsync($"{item} purchased!");
        }
        else
        {
            await ReplyAsync("Please enter of of the correct item emojis in order to 
            purchase");
        }
    }
