    using (SqlConnection connection = new SqlConnection("SQL connection string"))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("EXEC [dbo].[usp_getBorrowerDetails] @BookID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command = new SqlCommand(command.CommandText, connection);
                    command.Parameters.AddWithValue("@BookID", 1);
                    IDataReader reader = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Oops! Something went wrong." + ex.Message);
                }
            }
