    [FunctionName("Orchestration")]
    public static async Task Orchestration_Start([OrchestrationTrigger]  DurableOrchestrationContext ctx)
    {
    	try 
    	{
    		await ctx.CallActivityAsync("Foo");
    		await ctx.CallActivityAsync("Bar");
    		await Task.WhenAll(ctx.CallActivityAsync("Baz"), ctx.CallActivityAsync("Baz"));
    	}
    	catch(Exception)
    	{
    		// Do something...
    	}  
    }
