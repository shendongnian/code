    System.Text.StringBuilder myQuery = new System.Text.StringBuilder();
    myQuery.AppendFormat("SELECT TABLE_NAME FROM {0}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", valueOfCombobox);
    
    using (SqlCommand com = new SqlCommand(myQuery.ToString(), con))
    {
    	using (SqlDataReader reader = com.ExecuteReader())
    	{
    		//comboBox1.Items.Clear();
    		while (reader.Read())
    		{
    			comboBox1.Items.Add((string)reader["TABLE_NAME"]);
    		}
    	}
    }
