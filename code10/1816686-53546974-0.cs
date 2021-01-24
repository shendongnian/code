    private static readonly ConcurrentDictionary<Guid, SemaphoreSlim> SyncItems = new ConcurrentDictionary<Guid, SemaphoreSlim>();
    [HttpGet("api1")]
    public async Task<IActionResult> Api1()
    {
        Guid id = Guid.NewGuid();
        TimeSpan timeout = TimeSpan.FromSeconds(30);
        using (var semaphore = new SemaphoreSlim(0, 1))
        {
            if (SyncItems.TryAdd(id, semaphore))
            {
                try
                {
                    await SignalClientAsync(id);
                    if (await semaphore.WaitAsync(timeout))
                    {
                        await WhateverHappensNextAsync();
                    }
                    else { /* Handle timeout */ }
                }
                finally
                {
                    SyncItems.TryRemove(id, out SemaphoreSlim _);
                }
            }
            else { /* Handle very unexpected */ }
        }
        return Ok();
    }
    [HttpGet("api2/{id}")]
    public IActionResult Api2(Guid id)
    {
        if (SyncItems.TryRemove(id, out SemaphoreSlim semaphore))
        {
            semaphore.Release();
            return Ok();
        }
        return NotFound();
    }
