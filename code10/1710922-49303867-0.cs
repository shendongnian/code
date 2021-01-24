    DataSet data = new DataSet();
    String num;
    
    using (SqlConnection connection = new SqlConnection(connectionstring))
    {
    	using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Ip FROM IP_table", connection))
    	{
    		connection.Open();							
    		adapter.Fill(data);
    		
    		listBox1.DataSource = data.Tables[0];
    		listBox1.DisplayMember = "Ip";
    	}
    }
    
    num = listBox1.SelectedValue.ToString();		
