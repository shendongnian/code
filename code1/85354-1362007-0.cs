    public void FirstMethod() {
        using (var connection = CreateAndOpenConnection())
        using (var command = connection.CreateCommand()) {
            command.CommandText = "...";
            using (var reader = command.ExecuteReader()) {
                // do something with the data
                SecondMethod();
            }
        }
    }
    public void SecondMethod() {
        using (var connection = CreateAndOpenConnection())
        using (var command = connection.CreateCommand()) {
            command.CommandText = "...";
            using (var reader = command.ExecuteReader()) // Exception
            { }
        }
    }
    private SqlConnection CreateAndOpenConnection() {
        var conn = new SqlConnection(connectionString);
        conn.Open(); // perhaps dispose if this fails...
        return conn;
    }
