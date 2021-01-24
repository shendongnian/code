    string MyFunction(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                          Select(column => column.ColumnName);
        sb.AppendLine("['" + string.Join("','", columnNames) + "']");
        sb.Append("[");
        foreach (DataRow row in dt.Rows)
        {
            IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
            sb.AppendLine("['" + string.Join("','", fields) + "']");
        }
        sb.Append("]");
        return sb.ToString();
    }
