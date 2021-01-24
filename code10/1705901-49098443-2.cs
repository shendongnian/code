    public static async Task ShutDownClientWhenItTakesTooLong(IOwinContext context, 
        CancellationToken timeoutToken)
    {
        await Task.Delay(WAIT_MAX_MS, timeoutToken);
        if (timeoutToken.IsCancellationRequested)
        {
            return;
        }
        context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
    }
    public async Task ExecuteMainRequest(IOwinContext context, 
        CancellationTokenSource timeoutSource, Task timeoutTask)
    {
        try
        {
           await Next.Invoke(context);
        }
        finally
        {
           timeoutSource.Cancel();
           await timeoutTask;
        }
    }
    public override async Task Invoke(IOwinContext context)
    {
        using (var source = CancellationTokenSource.CreateLinkedTokenSource(
            context.Request.CallCancelled))
        using (var timeoutSource = new CancellationTokenSource())
        {
            source.CancelAfter(WAIT_MAX_MS);
            context.Set("RequestTerminated", source.Token);
            var timeoutTask = ShutDownClientWhenItTakesTooLong(context, timeoutSource.Token);
            await Task.WhenAny(
                timeoutTask,
                ExecuteMainRequest(context, timeoutSource, timeoutTask)
            );
        }
    }
