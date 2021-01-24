    [WebMethod]
    public string Student_Information(string Student_Code)
    {
		using( var connection = new MySqlConnection(ConnectionString))
		{
			connection.Open();
			using(var cmd = connection.CreateCommand())
			{
				cmd.CommandText = "select FirstName, LastName, Class from student where student_code=@code";
				cmd.Parameters.AddWithValue("@code", Student_Code);
				var rs = cmd.ExecuteReader();
				
				if( rs.Read() )
				{
					// read the data using something like
					var FirstName = rs["FirstName"].ToString();
					
					// or like this
					var LastName = rs.GetFieldValue<string>(rs.GetOrdinal("LastName"));
                    return "True"; // as per your example
				}
				else
				{
					// student not found
				}
				rs.Close();
			}
		}
        return "False";
	}	
