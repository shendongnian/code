    [FunctionName("OrchestratorFunc")]
    public static async Task<string> TransformOrchestration([OrchestrationTrigger] DurableOrchestrationContext context, TraceWriter log)
    {
        var dataList = context.GetInput<List<OrchestrationModel>>();
        var tasks = new List<Task>();
    
        foreach (var data in dataList)
        {
            tasks.Add(context.CallActivityAsync<string>("TransformToSql", new TransformModel(data));
        }
        await Task.WhenAll(tasks);
    }
