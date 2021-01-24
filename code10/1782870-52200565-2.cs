    [FunctionName("Orchestration")]
    public static async Task Orchestration_Start([OrchestrationTrigger]  DurableOrchestrationContext ctx)
    {
        await ctx.CallActivityAsync("Foo");
        await ctx.CallActivityAsync("Bar"); // THROWS!
        await Task.WhenAll(ctx.CallActivityAsync("Baz"), ctx.CallActivityAsync("Baz"));
    }
