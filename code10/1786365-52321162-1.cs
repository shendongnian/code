    public async Task RunAsync(Dictionary<int, Robots> botList)
    {
        this.botList = botList;
        Task[] tasks = new Task[botList.Count]; //5 tasks for each bot, 5 bots total in a list
    
        for (int i = 0; i < botList.Count; i++)
        {
            tasks[i] = botList[i].c.StartClient();
            botList[i].proc = await tasks[i];
    
            tasks[i] = botList[i].c.setConnection();
        }
        await Task.WhenAll(tasks);
        Form1.Log("All done");
    }
