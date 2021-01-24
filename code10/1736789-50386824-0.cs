    async Task Timer(Timespan interval, Func<Task> someCallback, CancellationToken token)
    {
         while (!ct.IsCancellationRequested)
         {
            await Task.Delay(interval, token);
            await someAction(); // Or someAction?.Invoke();
         }
    }
