    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            conn.Open();
            // Remaining code
        }
    }
    catch(Exception ex)
    {
        // Manage your exception here
    }
