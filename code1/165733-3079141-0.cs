    private static void CreateCommand(string queryString,
    string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
               connectionString))
        {
            try
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                //log and/or rethrow or ignore
            }
            catch (SqlException)
            {
                //log and/or rethrow or ignore
            }
            catch (ArgumentException)
            {
                //log and/or rethrow or ignore
            }
        }
    }
