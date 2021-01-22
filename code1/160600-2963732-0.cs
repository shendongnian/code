    public void JobToBeExecuted(JobExecutionContext context)
    {
        // Insert history record and retrieve primary key of inserted record.
        long historyId = InsertHistoryRecord(...);
        context.Put("HistoryIdKey", historyId);
    }
    public void JobWasExecuted(JobExecutionContext context,
                               JobExecutionException jobException)
    {
        // Retrieve history id from context and update history record.
        long historyId = (long) context.Get("HistoryIdKey");
        UpdateHistoryRecord(historyId, ...);
    }
