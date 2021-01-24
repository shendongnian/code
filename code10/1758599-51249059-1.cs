    public async Task CreateIndexOnNameField()
    {
        var keys = Builders<User>.IndexKeys.Ascending(x => x.Name);
        await _usersCollection.Indexes.CreateOneAsync(keys);
    }
