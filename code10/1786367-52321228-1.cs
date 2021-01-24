    public async Task RunAsync(Dictionary<int, Robots> botList)
    {
        this.botList = botList;
        var tasks = new List<Task>();
        foreach(var botKvp in botList)
        {
            var bot = botKvp.Value;
            bot.proc = await bot.c.StartClient();
            tasks.Add(bot.c.setConnection());
        }
        await Task.WhenAll(tasks);
        Form1.Log("All done");            
    }
