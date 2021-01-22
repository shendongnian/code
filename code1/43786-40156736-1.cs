    var objBulk = new BulkUploadToSql<PuckDetection>()
    {
            InternalStore = ListDetections,
            TableName= "PuckDetections",
            CommitBatchSize=1000,
            ConnectionString
    };
    objBulk.Commit();
