    public async void Stop() // async added here
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
