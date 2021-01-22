    using (var connection = new SqlConnection("Connection String here"))
    {
        connection.Open();
        var query = "SET IDENTITY_INSERT dbo.MyTable ON; INSERT INTO dbo.MyTable (IdentityColumn) VALUES (@identityColumnValue); SET IDENTITY_INSERT dbo.MyTable OFF;";
        using (var command = new SqlCommand(query, connection)
        {
            command.Parameters.AddWithValue("@identityColumnValue", 3);
            command.ExecuteNonQuery();
        }
    }
