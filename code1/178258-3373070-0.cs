    using (var connection = new SqlConnection("Connection String here"))
    {
        connection.Open();
        var query = "SET IDENTITY_INSERT dbo.MyTable ON; INSERT INTO dbo.MyTable (IdentityColumn) VALUES (3); SET IDENTITY_INSERT dbo.MyTable OFF;";
        using (var command = new SqlCommand(query, connection)
        {
            command.ExecuteNonQuery();
        }
    }
