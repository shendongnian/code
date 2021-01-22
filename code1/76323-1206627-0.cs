    List<string> myCols = new List<string>();
    DataTable schema = reader.GetSchemaTable();
    foreach (DataRow row in schema.Rows)
    {
        myCols.Add(row[schema.Columns["ColumnName"]]);
    }
