     string str = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
     string queryString =
            "SELECT price FROM price WHERE service ... ";
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }
            // Call Close when done reading.
            reader.Close();
        }
