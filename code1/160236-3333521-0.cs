    using (var connection = new SqlConnection("MyConnectionString")
    using (var command = connection.CreateCommand())
    {
        command.CommandText = String.Format("EXEC my_sp {0}, {1}, {2}", "a", "b", "c");
        connection.Open();
        command.ExecuteNonQuery();
    }
