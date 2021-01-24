    public void InsertInBatches(SqlConnection connection, DataTable data)
    {
        int currentBatch = 1;
    
        Console.WriteLine($"{data.Rows.Count.ToString("N0")} rows, {data.Rows.Count / 100000} batches");
        using (var copier = new SqlBulkCopy(connection))
        {
            copier.NotifyAfter = 100000;
            copier.BatchSize = 100000;
            copier.SqlRowsCopied += (s, e) => Console.WriteLine($"Batch {currentBatch++} complete.");
            copier.DestinationTableName = "dbo.BulkInsertPerformance";
            MapBulkCopyColumns(copier, data);
            copier.WriteToServer(data);
        }
    }
