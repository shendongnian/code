    using (SqlConnection sqlCon = new SqlConnection(connectionString))
    {
		SqlCommand sqlCmd = new SqlCommand("SELECT first_name FROM employee WHERE first_name = @firstName", sqlCon);
		DbParameter firstNameParameter = new SqlParameter("@firstName", txtFirstName.Text.Trim());
		sqlCmd.Parameters.Add(firstNameParameter);
    	sqlCmd.CommandType = CommandType.Text;
    	
    	sqlCon.Open();
    	
    	using (DbDataReader reader = sqlCmd.ExecuteReader())
    	while (reader.Read())
    	{
    		MessageBox.Show("already exists");
    		break;
    	}
    }
