    string connectionString = @"Data Source=DESKTOP-IE39262;Initial Catalog=Hospital;Integrated Security=True";
    string sqlQuery = "INSERT INTO Dept (Dept_No, DNombre, Loc) VALUES (@Dept_No,@DNombre,@Loc)";
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
	{
		command.Parameters.Add("@Dept_No", SqlDbType.VarChar,100).Value = dept.Dept_No;
		command.Parameters.Add("@DNombre", SqlDbType.VarChar, 100).Value = dept.DNombre;
		command.Parameters.Add("@Loc", SqlDbType.VarChar, 100).Value = dept.Loc;
		connection.Open();
		command.ExecuteNonQuery();
    }
