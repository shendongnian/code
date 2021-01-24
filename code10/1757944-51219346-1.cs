    protected void bind()
    {
    	var name = "John";
    	Session["name"] = name;
    	gv_Transaction.DataSource = getProductTransactions(name);
    	gv_Transaction.DataBind();
    }
    
    public IList<TransactionDetail> getProductTransactions(string p_UserName)
    {
    	var transList = new List<TransactionDetail>();
    	var queryStr = "SELECT * FROM TransactionDetail WHERE UserName = @user";
		
    	string tran_ID, offer_ID, user, Prod_Image, prod_Name;
    	decimal prod_Price;
		
    	using(var conn = new SqlConnection(connStr))
    	using(var cmd = new SqlCommand(queryStr, conn))
		{
			cmd.Parameters.AddWithValue("@user", p_UserName);
			conn.Open();
			using(var dr = cmd.ExecuteReader())
			{
				while(dr.Read())
				{
					tran_ID = dr["TransactionID"].ToString();
					offer_ID = dr["OfferId"].ToString();
					user = dr["UserName"].ToString();
					Prod_Image = dr["Image"].ToString();
					prod_Name = dr["ProductName"].ToString();
					prod_Price = decimal.Parse(dr["ProductPrice"].ToString());
					transList.Add(new TransactionDetail(tran_ID, offer_ID, user, Prod_Image, prod_Name, prod_Price));
				}
			}
    	}
    	return transList;
    }
