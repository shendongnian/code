    DataSet ds = new DataSet();
    DataRow[] foundRows;
    foundRows = ds.Tables[0].Select("MerchantName LIKE '%'", "MerchantName");
    
    DataTable DataTable2 = new DataTable();
    DataTable2 = ds.Tables[0].Clone();
    DataTable2.TableName = "DataTable2";
    foreach (DataRow dr in foundRows)
    {
        DataTable2.ImportRow(dr);
    }
    ds.Tables.Add(DataTable2); 
    Loadimages(ds);
