	using (SqlConnection sqlCon = new SqlConnection(connectionString))
		{
			sqlCon.Open();
			SqlCommand sqlCmd = new SqlCommand("UserInterface", sqlCon);
			sqlCmd.CommandType = CommandType.StoredProcedure;
			if (txtFirstName == sqlCmd.CommandText("EXISTS first_name FROM employee"))
			MessageBox.Show("already exists");
		}
