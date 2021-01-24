    public static string GetData (this DataTable table)
    {
        var builder = new StringBuilder ();
        foreach (DataRow row in table.Rows)
            foreach (DataColumn column in table.Columns)
                builder.Append (column.ColumnName).Append (": ").Append (row [column]).Append ("; ");
        return builder.ToString ();
    }
