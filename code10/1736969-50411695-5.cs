    [FunctionName("Orchestrator")]
    public static async Task Orchestrator(
        [OrchestrationTrigger] DurableOrchestrationContext context,
        TraceWriter log)
    {
        var tasks = new List<Task>(10);
        for (int i = 0; i < 10; i++)
        {
            int j = i;
            DateTime timeToStart = context.CurrentUtcDateTime.AddSeconds(10 * j);
            Task delayedActivityCall = context
                .CreateTimer(timeToStart, CancellationToken.None)
                .ContinueWith(t => context.CallActivityAsync("PerformSubtask", j));
            tasks.Add(delayedActivityCall);
        }
        await Task.WhenAll(tasks);
    }
