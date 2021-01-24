    IDataReader reader = null;
    SqlCommand command;
    try
    {
        SqlConnection connection = GetDBConnection();
        command = new SqlCommand(Constants.SP_BookBorrowerDetails, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@BookID", bookID);
        reader = base.ExecuteReader(command);
    }
    catch (System.Data.SqlClient.SqlException ex)
    {
        throw new Exception("Oops! Something went wrong.");
    }
