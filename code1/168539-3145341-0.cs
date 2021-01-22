    public static string DataTableToCSV(DataTable myTable)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < myTable.Columns.Count; i++)
        {
            sb.Append("\"");
            sb.Append(myTable.Columns[i].ColumnName);
            sb.Append("\"");
            if (i < myTable.Columns.Count - 1)
                sb.Append(",");
        }
        sb.AppendLine();
        foreach (DataRow dr in myTable.Rows)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                sb.Append("\"");
                sb.Append(dr.ItemArray[i].ToString());
                sb.Append("\"");
                if (i < dr.ItemArray.Length - 1)
                    sb.Append(",");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
