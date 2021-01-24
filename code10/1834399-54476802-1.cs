        long numberOfDocumentsToGenerate = long.Parse(ConfigurationManager.AppSettings["NumberOfDocumentsToImport"]);
        int numberOfBatches = int.Parse(ConfigurationManager.AppSettings["NumberOfBatches"]);
        long numberOfDocumentsPerBatch = (long)Math.Floor(((double)numberOfDocumentsToGenerate) / numberOfBatches);
        // Set retry options high for initialization (default values).
        client.ConnectionPolicy.RetryOptions.MaxRetryWaitTimeInSeconds = 30;
        client.ConnectionPolicy.RetryOptions.MaxRetryAttemptsOnThrottledRequests = 9;
        IBulkExecutor bulkExecutor = new BulkExecutor(client, dataCollection);
        await bulkExecutor.InitializeAsync();
        // Set retries to 0 to pass control to bulk executor.
        client.ConnectionPolicy.RetryOptions.MaxRetryWaitTimeInSeconds = 0;
        client.ConnectionPolicy.RetryOptions.MaxRetryAttemptsOnThrottledRequests = 0;
        BulkImportResponse bulkImportResponse = null;
        long totalNumberOfDocumentsInserted = 0;
        double totalRequestUnitsConsumed = 0;
        double totalTimeTakenSec = 0;
        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
