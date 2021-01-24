    public async Task SomeComplexFlow(Bot bot)
    {
        try
        {
            await bot.StartAsync();
            await bot.DoSomething();
            ...
        }
        catch(Exception exc)
        {
            ...
        }
    }
    var myBot=_bots[instance-1];
    await SomeComplexFlow(myBot);
