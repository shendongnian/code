    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    
    DataTable dt1 = new DataTable();
    dt1.Columns.Add(new DataColumn("Column1", typeof(System.String)));
    DataRow newSelRow1 = dt1.NewRow();
    newSelRow1["Column1"] = "Select";
    dt1.Rows.Add(newSelRow1);
    DataTable dt2 = new DataTable();
    dt2.Columns.Add(new DataColumn("Column1", typeof(System.String)));
    DataRow newSelRow2 = dt1.NewRow();
    newSelRow2["Column1"] = "DataRow1Data";  // Data
    dt2.Rows.Add(newSelRow2);
    ds1.Tables.Add(dt1);
    ds2.Tables.Add(dt2);
    ds1.Tables[0].Merge(ds2.Tables[0]);
