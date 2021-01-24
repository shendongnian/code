    public void savePurchseOrder(int Supplier_ID,string Date,string RequiredDate,double GrandTotal)
        {
            DynamicConnection con = new DynamicConnection();
            Main2 main = new Main2();
            con.mysqlconnection();
            con.sqlquery("Insert into TBL_PO(Supplier_ID,Date,RequiredDate,GrandTotal) values(@Supplier_ID,@Date,@RequiredDate,@GrandTotal)");
            con.cmd.Parameters.Add(new SqlParameter("@Supplier_ID", SqlDbType.Int));
            con.cmd.Parameters["@Supplier_ID"].Value = Supplier_ID;
            con.cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date));
            con.cmd.Parameters["@Date"].Value = Date;
            con.cmd.Parameters.Add(new SqlParameter("@RequiredDate", SqlDbType.Date));
            con.cmd.Parameters["@RequiredDate"].Value = RequiredDate;
            con.cmd.Parameters.Add(new SqlParameter("@GrandTotal", SqlDbType.Money));
            con.cmd.Parameters["@GrandTotal"].Value = GrandTotal;
            con.nonquery();
        }
    
    It should be: 
    
    public void savePurchseOrder(int Supplier_ID,string Date,string RequiredDate,double GrandTotal)
        {
            DynamicConnection con = new DynamicConnection();
            Main2 main = new Main2();
            con.mysqlconnection();
            con.sqlquery("Insert into TBL_PO(Supplier_ID,Date,RequiredDate,GrandTotal) values(@Supplier_ID,@Date,@RequiredDate,@GrandTotal)");
            con.cmd.Parameters.Add(new SqlParameter("@Supplier_ID", SqlDbType.Int));
            con.cmd.Parameters["@Supplier_ID"].Value = Supplier_ID;
            con.cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date));
            con.cmd.Parameters["@Date"].Value = Date;
            con.cmd.Parameters.Add(new SqlParameter("@RequiredDate", SqlDbType.Date));
            con.cmd.Parameters["@RequiredDate"].Value = RequiredDate;
            con.cmd.Parameters.Add(new SqlParameter("@GrandTotal", SqlDbType.Money));
            con.cmd.Parameters["@GrandTotal"].Value = GrandTotal;
            con.nonquery();
        }
