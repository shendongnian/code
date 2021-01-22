    public bool StoreAcceleration(string strStringSession, DateTime receivedTime, double accelerationX, double accelerationY, double accelerationZ)
    {
        string select =
            "INSERT INTO acceleration (session_id, measurement_time, acceleration_x, acceleration_y, acceleration_z) VALUES (@sessionID, @measurementTime, @accelerationX, @accelerationY, @accelerationZ)";
        int sessionID = getSessionID(strStringSession);
        if (sessionID == 0)
            return false;
        updateSessions(sessionID);
        
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(select, conn))
        {
            cmd.Parameters.AddWithValue("sessionID", sessionID);
            cmd.Parameters.AddWithValue("measurementTime", receivedTime);
            cmd.Parameters.AddWithValue("accelerationX", accelerationX);
            cmd.Parameters.AddWithValue("accelerationY", accelerationY);
            cmd.Parameters.AddWithValue("accelerationZ", accelerationZ);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
