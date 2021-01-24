    [FunctionName("OrchestratorFunc")]
    public static async Task<string> TransformOrchestration([OrchestrationTrigger] DurableOrchestrationContext context, TraceWriter log)
    {
    	var dataList = context.GetInput<List<OrchestrationModel>>();
    	var tasks = new List<Task>();
    
    	foreach (var data in dataList)
    	{
    		await context.CallActivityAsync<string>("TransformToSql1", new TransformModel(data);
            await context.CallActivityAsync<string>("TransformToSql2", new TransformModel(data);
    	}
    }
