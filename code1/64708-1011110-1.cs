    SqlCommand insertCommand = new SqlCommand(
       "spInsertMyType", connection);
     insertCommand.CommandType = CommandType.StoredProcedure;
     SqlParameter tvpParam = 
        insertCommand.Parameters.AddWithValue(
        "@Data", dataReader);
     tvpParam.SqlDbType = SqlDbType.Structured;
