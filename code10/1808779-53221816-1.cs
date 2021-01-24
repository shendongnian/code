    public async Task Stop() // async added here, void changed to Task
    {
        if (running)
        {
            tokenSource.Cancel();
            await ping; // await here
            ping.Dispose();
            tokenSource.Dispose();
        }
        running = false;
    }
