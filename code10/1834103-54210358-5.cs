    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    SqlDataAdapter SqlDA = new SqlDataAdapter();
    SqlDA = new SqlDataAdapter("select * from tblProductInventory", myConn);
        SqlDA.Fill(ds1, "MyTable");
        SqlDA = new SqlDataAdapter("select * from tblProductCategories", myConn);
        SqlDA.Fill(ds2, "MyTable");
    // add a column categoryid
    ds1.Tables[0].Columns.
    Add("CategoryId",typeof(string));
    ds1.Merge(ds2);
    ds1.Merge(ds2, true, MissingSchemaAction.Add);
        ds1.AcceptChanges();
        GridView1.DataSource = ds1.Tables[0].DefaultView;
        GridView1.DataBind();
    ds1.Merge(ds2);
