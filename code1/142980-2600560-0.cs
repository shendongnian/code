    public string Name {get; set;}
    //Constructor
    using (connection)
    {
        SqlCommand command = new SqlCommand("StoredProcName", connection);
        command.Parameters.Add(new SqlParameter("name", Name));
        connection.Open();
        command.ExecuteNonQuery();
    }
