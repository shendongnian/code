    DataTable dt = new DataTable("Hello world");
    dt.Columns.Add("Col1");
    dt.Rows.Add("Val1");
    dt.Rows.Add("Val1 ");
    dt.Rows.Add("Val3");
    List<DataColumn> cols = new List<DataColumn>();
    cols.Add(dt.Columns["Col1"]); 
    try
    {
        dt.PrimaryKey = cols.ToArray();
    }
    catch (Exception e)
    {
        // Throws "These columns don't currently have unique values"    
    }
