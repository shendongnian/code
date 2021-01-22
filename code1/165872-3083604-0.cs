    DataTable dt = ds.Tables[0];
    
    // 1. set DisplayMember and ValueMember
    lbSiteCode.DisplayMember = dt.Columns[0].ColumnName;
    lbSiteCode.ValueMember = dt.Columns[1].ColumnName;
    // 2. set DataSource
    lbSiteCode.DataSource = dt;
