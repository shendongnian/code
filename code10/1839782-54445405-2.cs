    using (SqlConnection sqlCon = new SqlConnection(connectionString))
    {
    	SqlCommand sqlCmd = new SqlCommand("SELECT first_name FROM employee WHERE first_name = '" + txtFirstName.Text.Trim() + "'", sqlCon);
    	sqlCmd.CommandType = CommandType.Text;
    	
    	sqlCon.Open();
    	
    	using (DbDataReader reader = sqlCmd.ExecuteReader())
    	while (reader.Read())
    	{
    		MessageBox.Show("already exists");
    		break;
    	}
    }
