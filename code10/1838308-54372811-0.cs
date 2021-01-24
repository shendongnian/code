    private async Task AddAuctionDraftToDb(List<int> draftIds)
    {
        var query = "INSERT INTO ..";
       
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
