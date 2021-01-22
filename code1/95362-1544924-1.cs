    ThreadPool.QueueUserWorkItem(delegate {
        using (SqlConnection sqlConnection = new SqlConnection("blahblah;Asynchronous Processing=true;") {
            using (SqlCommand command = new SqlCommand("someProcedureName", sqlConnection)) {
                sqlConnection.Open();
    
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@param1", param1);
    
                command.ExecuteNonQuery();
            }
        }
    });
