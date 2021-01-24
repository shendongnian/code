    using (var sqlConnection = new SqlConnection(Connection.connectionString))
    using (var cmd = new SqlCommand("INSERT INTO IngredientTypes (Name) VALUES (@name)",  sqlConnection))
    {
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 155).Value = Name;
        sqlConnection.Open();
        cmd.ExecuteNonQuery();
    }
