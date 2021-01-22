    SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        using (SqlCommand command = new SqlCommand(queryString, connection))
        {
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
    catch (Exception e)
    {
        // ...handle, rethrow. Also, you might want to catch
        // more specific exceptions...
    }
    finally
    {
        connection.Close();
    }
