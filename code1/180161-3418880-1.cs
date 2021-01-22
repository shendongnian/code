    foreach (DataTable dt in tablesFromDB)
    {
        foreach (DataColumn dc in dt.Columns)
        {
            // Do something with the column names and types here
            // dc.ColumnName is the column name for the current table
            // dc.DataType.ToString() is the name of the type of data in the column
        }
    }
