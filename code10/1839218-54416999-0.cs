    DataTable dt = new DataTable();
        
    dt.Columns.Add(new DataColumn("ID1", typeof(int)));
        
    dt.Columns.Add(new DataColumn("ID2", typeof(int)));
    
    
    DataRow row = dt.NewRow();
    [0] = 1;
    dt.Rows.Add(row);
    
    row = dt.NewRow();
    row[0] = 2;
    dt.Rows.Add(row);
    
    row = dt.NewRow();
    row[0] = 3;
    dt.Rows.Add(row);
    
    row = dt.NewRow();
    row[1] = 1;
    dt.Rows.Add(row);
    
    row = dt.NewRow();
    row[1] = 4;
    dt.Rows.Add(row);
    
    
    var tbl1 = dt.AsEnumerable().Where(t => !t.IsNull("ID1")).CopyToDataTable();
    tbl1.Columns.Remove("ID2");
    tbl1.Columns["ID1"].ColumnName = "ID";
    
    var tbl2 = dt.AsEnumerable().Where(t => !t.IsNull("ID2")).CopyToDataTable();
    tbl2.Columns.Remove("ID1");
    tbl2.Columns["ID2"].ColumnName = "ID";
    
    var query = tbl1.AsEnumerable().Concat(tbl2.AsEnumerable());
