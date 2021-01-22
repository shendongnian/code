    using (sqlConnection theconnection = new sqlconnection(initialise it))
    {
     using (SqlCommand testCommand = new SqlCommand())
            {
                testCommand.Connection = theConnection
                testCommand.CommandType = CommandType.StoredProcedure;
                testCommand.CommandText = "prc_AddOrderStatus";
                testCommand.Parameters.Add("@orderID", SqlDbType.NVarChar).Value = orderID;
                testCommand.ExecuteNonQuery();
            }
    }
