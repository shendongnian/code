    private static void SqlCommandPrepareEx(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);
    
            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE Pending_List set room_status=@roomStatus " +
                "WHERE Class_ID=@classId AND Other=@Other";
            SqlParameter classIdParam = new SqlParameter("@classId", SqlDbType.Int, 0);
            SqlParameter OtherParam = new SqlParameter("@OtherParameter", SqlDbType.Int, 0);
            SqlParameter roomStatusParam = 
                new SqlParameter("@roomStatus", SqlDbType.Text, 100);
            classIdParam.Value = 1;
            roomStatusParam.Value = "Still Pending";
            otherParam.Value = 10;
            command.Parameters.Add(classIdParam);
            command.Parameters.Add(roomStatusParam);
            command.Parameters.Add(otherParam);
    
            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();    
        }
    }
