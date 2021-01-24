    public async Task ExecuteMyNonQueryAsync() {    
        using (var conn = GetNewConnection()) {
            var query = "DELETE FROM blah blah blah WHERE blah blah;"
            await conn.OpenAsync();
            using (var cmd = new NpgsqlCommand(query, conn)) {
                cmd.Parameters.AddRange(new[] {
                    new NpgsqlParameter("@a", A),
                    new NpgsqlParameter("@b", B)
                });
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
