    public List<string> GetColumnNames(SqlDataReader r)
    {
        List<string> ColumnNames = new List<string>();
        DataTable schemaTable = r.GetSchemaTable();
        DataRow row = schemaTable.Rows[0];
        foreach (DataColumn col in schemaTable.Columns)
        {
            if (col.ColumnName == "ColumnName") { ColumnNames.Add(row[col.Ordinal].ToString()); break; }
        }
        return ColumnNames;
    }
