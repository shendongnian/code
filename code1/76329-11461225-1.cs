    public bool ColumnExists(IDataReader reader, string columnName)
    {
      return reader.GetSchemaTable()
                   .Rows
                   .OfType<DataRow>()
                   .Any(row => row["ColumnName"].ToString() == columnName);
    }
