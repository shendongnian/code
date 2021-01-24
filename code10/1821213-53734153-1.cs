    public static async Task InsertUser(User user)
    {
        using (var conn = new SqlConnection(Configuration.ConnectionString))
        {
            var cmd = new SqlCommand();
            //etc.
            await cmd.ExecuteNonQueryAsync();
        }
    }
