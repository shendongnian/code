    private DataTable JoinDataTables(DataTable t1, DataTable t2, params Func<DataRow, DataRow, bool>[] joinOn)
    {
        DataTable result = new DataTable();
        foreach (DataColumn col in t1.Columns)
        {
            if (result.Columns[col.ColumnName] == null)
                result.Columns.Add(col.ColumnName, col.DataType);
        }
        foreach (DataColumn col in t2.Columns)
        {
            if (result.Columns[col.ColumnName] == null)
                result.Columns.Add(col.ColumnName, col.DataType);
        }
        foreach (DataRow row1 in t1.Rows)
        {
            var joinRows = t2.AsEnumerable().Where(row2 =>
                {
                    foreach (var parameter in joinOn)
                    {
                        if (!parameter(row1, row2)) return false;
                    }
                    return true;
                });
            foreach (DataRow fromRow in joinRows)
            {
                DataRow insertRow = result.NewRow();
                foreach (DataColumn col1 in t1.Columns)
                {
                    insertRow[col1.ColumnName] = row1[col1.ColumnName];
                }
                foreach (DataColumn col2 in t2.Columns)
                {
                    insertRow[col2.ColumnName] = fromRow[col2.ColumnName];
                }
                result.Rows.Add(insertRow);
            }
        }
        return result;
    }
