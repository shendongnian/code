    public async Task Handle(DetectionLoggingIntegrationEvent @event)
    {
        var dt = new DataTable();
        dt.Columns.Add("ScreeningId", typeof(long));
        dt.Columns.Add("Message");
        dt.Columns.Add("Time", typeof(long));
    
        @event.OperationTimePairs.ForEach(pair => dt.Rows.Add(@event.ScreeningId, pair.Key, pair.Value));
    
        using (var sqlBulk = new SqlBulkCopy(_configProvider.FdbConnectionString))
        {
            var mapping = new SqlBulkCopyColumnMapping("ScreeningId", "ScreeningId");
            sqlBulk.ColumnMappings.Add(mapping);
    
            mapping = new SqlBulkCopyColumnMapping("Message", "Message");
            sqlBulk.ColumnMappings.Add(mapping);
    
            mapping = new SqlBulkCopyColumnMapping("Time", "Time");
            sqlBulk.ColumnMappings.Add(mapping);
    
            sqlBulk.DestinationTableName = "DetectionLoggingTime";
            sqlBulk.WriteToServer(dt);
        }
    }
