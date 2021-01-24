    string connectionString = "*** DB Connection String ***";
    using (var p = new ChoCSVReader<MyClass>("*** Your CSV File ***")
        .WithFirstLineHeader()
        )
    {
        using (SqlBulkCopy bcp = new SqlBulkCopy(connectionString))
        {
            bcp.DestinationTableName = "** DB Table Name **";
            bcp.EnableStreaming = true;
            bcp.BatchSize = 10000;
            bcp.BulkCopyTimeout = 0;
            bcp.NotifyAfter = 10;
            bcp.SqlRowsCopied += delegate (object sender, SqlRowsCopiedEventArgs e)
            {
                Console.WriteLine(e.RowsCopied.ToString("#,##0") + " rows copied.");
            };
            bcp.WriteToServer(p.AsDataReader());
        }
    }
