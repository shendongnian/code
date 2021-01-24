    public async Task<DataTable> CallDb(string connStr, string sql)
    {
        var dt = new DataTable();
        var connection = new SqlConnection(connStr);
        var reader = await connection.CreateCommand().ExecuteReaderAsync();
        dt.Load(reader);
        return dt;
    }
