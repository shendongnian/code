    private static void ExecuteSqlCommand(string queryString,
    string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
               connectionString))
        {
            try
            {
                using(var command = new SqlCommand(queryString, connection))
                {
                command.Connection.Open();
                var result = command.ExecuteNonQuery();
                // Do whats needed with the result.
                }
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
