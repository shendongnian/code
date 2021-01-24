    public static void Run(TimerInfo myTimer, IEnumerable<Document> documents,
        TraceWriter log)
    {
      log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
      log.Info("Documents modified " + documents.Count());
    }
