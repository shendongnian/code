    Task task = Task.Factory.StartNew(() =>
    {
        token.ThrowIfCancellationRequested();
        work1();
        token.ThrowIfCancellationRequested();
        work2();
        token.ThrowIfCancellationRequested();
        work3();
        token.ThrowIfCancellationRequested();
        work4();
        ...
    }, token);
    
    if (!task.Wait(TimeSpan.FromSeconds(10))
    {
        tokenSource.Cancel();
        // handle cancel case
    } else {
        // handle done case
    }
