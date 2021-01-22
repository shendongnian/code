        using (SqlCommand command = new SqlCommand("someProcedureName", sqlConnection))
        {
            sqlConnection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@param1", param1);
            command.BeginExecuteNonQuery((ar) =>
            {
                var cmd = (SqlCommand)ar.AsyncState;
                cmd.EndExecuteNonQuery(ar);
                cmd.Connection.Close();
            }, command);
        }
    }
