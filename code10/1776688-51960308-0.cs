    public int userLogin() {
    	string connStr = ConfigurationManager.ConnectionStrings["conn"].ToString();
    	using (SqlConnection conn = new SqlConnection(connStr))
    	using (SqlCommand cmd = new SqlCommand("fucn_LOg", conn)) {
        	try {
            	cmd.Connection.Open();
            	cmd.CommandType = System.Data.CommandType.StoredProcedure;
            	cmd.Parameters.AddWithValue("@param1", TB_1.Text);
            	cmd.Parameters.AddWithValue("@param2", TB_2.Text);
            	var result = cmd.ExecuteScalar();
            	return Int32.Parse(result.ToString());
        	}
        	catch (Exception ex) {
            	MessageBox.Show(ex.ToString());
            	return -1;
        	}
        	finally {
            	if (cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();
        	}
    	}
	}
