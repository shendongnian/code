    public static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0, 1);
    public static async Task AddEntry(string url, DateTime time, User user)
    {
        UpdateUser(user);
        await _semaphoreSlim.WaitAsync();
        try
        {
            // do job
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
