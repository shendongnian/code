    private static string[] ReadData(string queryString, string connectionString)
    {
        var result = new List<string>();
        using (var connection =
                    new SqlConnection(connectionString))
        {
            var command =
                new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                // Please note I am just reading the value of the first column
                // so if you want other columns, you would need to modify this
                // to suit your needs.
                result.Add(reader[0].ToString());
            }
            // Call Close when done reading.
            reader.Close();
        }
        return result.ToArray();
    }
