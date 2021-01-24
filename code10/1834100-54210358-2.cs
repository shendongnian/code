    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    SqlDataAdapter SqlDA = new SqlDataAdapter();
    SqlDA = new SqlDataAdapter("select * from tblProductInventory", myConn);
        SqlDA.Fill(ds1, "MyTable");
        SqlDA = new SqlDataAdapter("select * from tblProductCategories", myConn);
        SqlDA.Fill(ds2, "MyTable");
