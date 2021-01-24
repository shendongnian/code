    protected DataTable ExecuteSp(string lat, string lng)
    {
        SqlConnection cnn = new SqlConnection("Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password");
    	SqlCommand cmd = new SqlCommand();
    	SqlDataAdapter da = new SqlDataAdapter();
    	DataTable dt = new DataTable();
    	try
    	{
    		cmd = new SqlCommand("get_nearest_Restaurants", pl.ConnOpen());
    		cmd.Parameters.Add(new SqlParameter("@lat", lat));
    		cmd.Parameters.Add(new SqlParameter("@lng", lng));
    		cmd.CommandType = CommandType.StoredProcedure;
    		da.SelectCommand = cmd;
    		da.Fill(dt);
    		dataGridView1.DataSource = dt;
    	}
    	catch (Exception x)
    	{
    		MessageBox.Show(x.GetBaseException().ToString(), "Error",
    				MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    	finally
    	{
    		cmd.Dispose();
    	}
    	return dt;
    }
