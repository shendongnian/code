    private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0, 1);
    private async void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        bool busy = await _semaphoreSlim.WaitAsync(0); //instantly return with false if busy
        if(!busy)
        {
            try
            {
                //some logic
                await SomeAsyncCommand();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
        else
        {
            await Reply("Stuff's busy yo"); // falling thru, no need to process every request
        }
    }
