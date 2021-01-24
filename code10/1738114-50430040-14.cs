    public static string GetData (this DataTable table, List <string> columns = null)
    {
        var builder = new StringBuilder ();
        foreach (DataRow row in table.Rows)
            if (columns == null)
                foreach (DataColumn column in table.Columns)
                    builder.Append (column.ColumnName).Append (": ").Append (row [column]).Append ("; ");
            else
                foreach (var column in columns)
                    builder.Append (column).Append (": ").Append (row [column]).Append ("; ");
        return builder.ToString ();
    }
