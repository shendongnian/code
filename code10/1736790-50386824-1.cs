    async Task Timer(Timespan interval, Func<Task> someCallback, CancellationToken token)
    {
         while (!token.IsCancellationRequested)
         {
            await Task.Delay(interval, token);
            await someAction(); // Or someAction?.Invoke();
         }
    }
