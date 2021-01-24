    [Command("test", RunMode = RunMode.Async)]
    public async Task PlayAsync()
    {
        string text = "Message To Delete"; //text that bot shows
        var m = await ReplyAsync(text); //bot displays text
        const int delay = 10000; //delay to wait
        await Task.Delay(delay); //starting delay
        await Context.Message.DeleteAsync(); //deleting messages after delay
        await m.DeleteAsync();
    }
