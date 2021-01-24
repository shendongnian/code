    using (TransactionScope ts = new TransactionScope())
    using (Sqlconnection con = new SqlConnection("my connectionstring")
    using (var command = SqlCommand("mystoerprocedeure", con))
    {
        command.CommandType = CommandType.StoredProcedure;
        if (commandTimeout.HasValue)
        {
            command.CommandTimeout = commandTimeout.Value;
        }
        var param = command.Parameters.AddWithValue(@myparam, datatableobject);
        param.SqlDbType = SqlDbType.Structured;
        command.ExecuteNonQuery();
        ts.Complete();
    }
