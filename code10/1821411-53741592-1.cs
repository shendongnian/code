    private static bool DoesSubjectExist(string input)
	{
	    using (SqlConnection connection = new SqlConnection(connectionString))
	    {
	        connection.Open();
	        // Note that query will probably need to be changed too for a more optimal solution.
	        using (SqlCommand command = new SqlCommand("SELECT Subject_Name FROM Subject WHERE Subject_Name ='" + input + "'", connection)) 
	        {
	            using (SqlDataReader reader = command.ExecuteReader())
	            {
	                // Do we need this loop?
	                while (reader.Read())
	                {
	                    // There is at least one match - so the subject exists.
	                	if (reader.FieldCount > 0) return true;
	                }
	            }
	        }
	        return false; // If we get here, we didn't find anything.
	    }
	}  
