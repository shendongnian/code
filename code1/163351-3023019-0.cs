    System.Data.DataTable dt;
    dt = new System.Data.DataTable();
    foreach(System.Data.DataColumn col in dt.Columns)
    {
         System.Diagnostics.Debug.WriteLine(col.ColumnName);
    }
