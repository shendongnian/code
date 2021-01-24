    [FunctionName("PerformSubtask")]
    public static void Activity([ActivityTrigger] int j, TraceWriter log)
    {
        log.Warning($"{DateTime.Now:o}: {j:00}");
    }
