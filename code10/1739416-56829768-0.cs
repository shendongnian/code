    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        var cts = new CancellationTokenSource(context.RemainingTime);
        var myResult = await MyService.DoSomethingAsync(cts.Token);
    }
