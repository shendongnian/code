    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
    {
        bulkCopy.EnableStreaming = true;
        bulkCopy.BulkCopyTimeout = 0;
        using (var reader = new MyRowCountDataReader(dataReader))
        {
            reader.NotifyAfter = 1000;
            reader.RowRead += (sender, args) => { ... };
            bulkCopy.WriteToServer(reader);
        }
    }
