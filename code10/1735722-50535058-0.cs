    public string GetCSVFromDataTabe(DataTable datatable)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Join(",", dt.Columns.ToList<DataColumn>().Select(column => column.ColumnName).ToList()) + "\n");
        dataTable.Rows.ToList<DataRow>().ForEach(row => sb.Append(string.Join(",", row.ItemArray) + "\n"));
        return stringBuilder.ToString();
    }
