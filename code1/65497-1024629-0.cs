    private static DataTable GetTable()
    {
        var list = new List<DataColumn>();
        list.Add(new DataColumn("amount", typeof(Double)));
        list.Add(new DataColumn("date", typeof(DateTime)));
        var table = new DataTable("statement");
        table.Columns.AddRange(list.ToArray());
    
        var row = table.NewRow();
        row["amount"] = 1.2d;
        row["date"] = DateTime.Now.Date;
    
        table.Rows.Add(row);
        return table;
    }
    private static void WriteData()
    {
        string strConnection = "Server=(local);Database=ScratchDb;Trusted_Connection=True;";
        using (var bulk = new SqlBulkCopy(strConnection, SqlBulkCopyOptions.KeepIdentity & SqlBulkCopyOptions.KeepNulls))
        {
            bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("amount", "amount"));
            bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping("date", "date"));
            bulk.BatchSize = 25;
            bulk.DestinationTableName = "statement";
            bulk.WriteToServer(GetTable());
        }
    }
