    using (SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True"))
    {
    	SqlCommand cmd = new SqlCommand(@"INSERT INTO [StockManagement].[dbo].[Product]
       ([ProductID]
       ,[ProductName]
       ,[SalePrice]
       ,[PurchasePrice]
       ,[Status])
    VALUES
       (@pid, @pname, @salePrice, @purPrice, @status)", con);
    
    	cmd.Parameters.Add("@pid", SqlDbType.Int).Value = int.Parse(pcodetxt.Text);
    	cmd.Parameters.Add("@pname", SqlDbType.VarChar).Value = pnametxt.Text;
    	cmd.Parameters.Add("@salePrice", SqlDbType.Money).Value = decimal.Parse(rtlpricetxt);
    	cmd.Parameters.Add("@purPrice", SqlDbType.Money).Value = int.Parse(purpricetxt.Text);
    	cmd.Parameters.Add("@status", SqlDbType.Int).Value = statuscbox.SelectedIndex;
    
    	con.Open();
    	cmd.ExecuteNonQuery();
    	con.Close();
    }
