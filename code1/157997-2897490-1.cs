    SqlCommand MyCommand = new SqlCommand("sp_SalesExtract", session.Connection);
    MyCommand.CommandType = CommandType.StoredProcedure;
    SqlDataReader MyDataReader = MyCommand.ExecuteReader();
    while (MyDataReader.Read())
    {
        // handle row data (MyDataReader[0] ...)
    }
