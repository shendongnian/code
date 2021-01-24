    public List<string> GetTableColumns(string tableName)
    {
        if (tableName == null)
            throw new ArgumentNullException(nameof(tableName));
        if (string.IsNullOrWhitespace(tableName))
            throw new ArgumentException("Table name can't be empty!", nameof(tableName));
        List<string> colCollection = new List<string>();
        using (var cmd = MyDB.GetSqlStringCommand($"SELECT * FROM {tableName}"))
        using (var reader = MyDB.ExecuteReader(cmd))
            foreach (DataRow r in reader.GetSchemaTable().Rows)
                colCollection.Add(r["ColumnName"].ToString());
        return colCollection;
    }
