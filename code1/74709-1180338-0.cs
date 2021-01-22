     // Configure the SqlCommand and table-valued parameter.
     SqlCommand insertCommand = new SqlCommand(
       "usp_InsertCategories", connection);
     insertCommand.CommandType = CommandType.StoredProcedure;
     SqlParameter tvpParam = 
        insertCommand.Parameters.AddWithValue(
        "@tvpNewCategories", dataReader);
     tvpParam.SqlDbType = SqlDbType.Structured;
