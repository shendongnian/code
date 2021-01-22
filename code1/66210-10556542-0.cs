    DataView view = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
    
    DataTable table = view.ToTable();
    DataSet ds = new DataSet();
    ds.Tables.Add(table);
