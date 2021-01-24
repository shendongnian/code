    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["key"].ConnectionString;
    using (SqlConnection sqlConn = new SqlConnection(connStr))
    {
    	sqlConn.Open();
    	using (SqlCommand cmd = new SqlCommand("SELECT item_name FROM TEST_ITEMS I JOIN TESTS T ON I.test_id = T.test_id WHERE test_name = @testName", sqlConn))
    	{
    		cmd.Parameters.AddWithValue("testName", TextBox1.Text);
    		
    		DataTable dt = new DataTable();
    		using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
    		{
    			adapter.Fill(dt);
    		}
    		
    		// use dt as you did
    	}
    }
