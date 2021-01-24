    private static string DoesSubjectExist(string input)
	{
	    string exists = "";
	    using (SqlConnection connection = new SqlConnection(connectionString))
	    {
	        connection.Open();
	        using (SqlCommand command = new SqlCommand("SELECT Subject_Name FROM Subject WHERE Subject_Name ='" + input + "'", connection))
	        {
	            using (SqlDataReader reader = command.ExecuteReader())
	            {
	                while (reader.Read())
	                {
	                    for (int j = 0; j < reader.FieldCount; j++)
	                    {
	                        exists = reader.GetValue(j) + "";
	                    }
	                }
	            }
	        }
	        return exists;
	    }
	} 
