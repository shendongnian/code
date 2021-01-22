    DbConnection db = new SqlConnection(connection_string);
    try
    {
        db.Open();
    }
    catch ( SqlException e )
    {
        // Cannot connect to database
    }
