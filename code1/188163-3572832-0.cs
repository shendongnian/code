    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO table1 (column1, column2) VALUES (@param1, @param2)";
        command.Parameters.Add("@param1", SqlDbType.DateTime).Value = 
            DateTime.TryParse(txtDate.Text, out d) ?
                (object)d :
                DBNull.Value // inserting NULL
        ...
        connection.Open();
        command.ExecuteNonQuery();
    }
