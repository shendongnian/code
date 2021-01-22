    public static bool DataTableToCSV(DataTable dtSource, StreamWriter writer, bool includeHeader)
    {
        if (dtSource == null || writer == null) return false;
    
        if (includeHeader)
        {
            string[] columnNames = dtSource.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray<string>();
            writer.WriteLine(String.Join(",", columnNames));
            writer.Flush();
        }
    
        foreach (DataRow row in dtSource.Rows)
        {
            string[] fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray<string>();
            writer.WriteLine(String.Join(",", fields));
            writer.Flush();
        }
    
        return true;
    }
