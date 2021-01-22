public void GetData(string studentID)
{
    using (SqlConnection connection = new SqlConnection(Settings.Default.connectionString))
    {
        connection.Open();
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_stored_proc";
            command.Parameters.AddWithValue("@student_id", studentID);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                // do something with the data
            }
        }
    }
}
