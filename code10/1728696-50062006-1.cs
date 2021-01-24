    private static bool OpenSqlConnection(string connectionString)
    {
        bool return = false;
        try 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return = true;
        }
        catch (Exception ex)
        {
            return = false;
        }
        finally 
        {
            connection.Close();
        }
        return return;
    }
