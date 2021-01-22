    public static bool ChangeColumnDataType(DataTable table,string columnname,Type newtype)
    {
        if (table.Columns.Contains(columnname) == false)
            return false;
            
        DataColumn column= table.Columns[columnname];
        if (column.DataType == newtype)
            return true;
        try
        {
            DataColumn newcolumn = new DataColumn("temperary", newtype);
            table.Columns.Add(newcolumn);
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    row["temperary"] = Convert.ChangeType(row[columnname], newtype);
                }
                catch
                {
                }
            }
            table.Columns.Remove(columnname);
            newcolumn.ColumnName = columnname;
        }
        catch (Exception)
        {
            return false;
        }
            
        return true;
    }
