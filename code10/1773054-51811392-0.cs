    var conn = new SqlConnection("Your connection informations here");
    conn.Open();
    
    var command = new SqlCommand("Select * from YourTable", conn);
    
    using (SqlDataReader reader = command.ExecuteReader())
    {
    	while (reader.Read())
    	{
    		// Pass the useful informations to your panel
    		var pnl = new MyCustomPanel(reader["Id"].ToString(), reader["Property_Type1"].ToString());
    		flowLayoutPanel1.Controls.Add(pnl);
    	}
    }
    
    conn.Close();
