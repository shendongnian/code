    string connectionString = @"Data Source=DESKTOP-IE39262;Initial Catalog=Hospital;Integrated Security=True";
    string sqlQuery = "INSERT INTO Dept (Dept_No, DNombre, Loc) VALUES (@Dept_No,@DNombre,@Loc)";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	connection.Open();
    	using (SqlCommand command = new SqlCommand(sqlQuery, connection))
    	{
    		command.Parameters.Add(new SqlParameter("@Dept_No", dept.Dept_No));
    		command.Parameters.Add(new SqlParameter("@DNombre", dept.DNombre));
    		command.Parameters.Add(new SqlParameter("@Loc", dept.Loc));
    		command.ExecuteNonQuery();
    	}
    }
