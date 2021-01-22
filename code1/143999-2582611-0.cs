    public DataTable ResultSetToDataTable(SqlCeResultSet set)
    {
        DataTable dt = new DataTable();
        // copy columns
        for (int col = 0; col < set.FieldCount; col++)
        {
            dt.Columns.Add(set.GetName(col), set.GetFieldType(col));
        }
        // copy data
        while (set.Read())
        {
            DataRow row = dt.NewRow();
            for (int col = 0; col < set.FieldCount; col++)
            {
                row[col] = set.GetValue(col);
            }
            dt.Rows.Add(row);
        }
        return dt;
    }
