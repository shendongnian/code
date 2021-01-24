    string sqlQuery =  "SELECT ID FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
    {
        command.Parameters.Add("@FirstName", SqlDbType.VarChar,100).Value = txtBoxFirst.Text;
        command.Parameters.Add("@LastName", SqlDbType.VarChar, 100).Value = txtBoxLast.Text;
    	
    	SqlDataReader read = dataAdapter.SelectCommand.ExecuteReader();
    
    	while (read.Read())
    	{
    		pID = (Int32.Parse(read["ID"].ToString()));
    	}
    }
