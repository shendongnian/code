    //pseudo code:
    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("column1");
    dt.Columns.Add(dc);
    DataRow dr = dt.NewRow();
    dr["column1"] = "value1";
    dt.Rows.AddNew(dr);
    
    myDataGrid.DataSource = dt;
    myDataGrid.DataBind();
