    using (var connection = new OleDbConnection(connectionString))
    {
        connection.Open();
        var command = new OleDbCommand(queryString, connection);
        var reader = command.ExecuteReader();
        var person = new Person();
        if (reader.Read())
        {
            person.Name = reader["Name"].ToString();
            person.Age = Convert.ToInt32(reader["Age"]);
        }
        return person;
    }
