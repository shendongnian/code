    public async Task<List<MyTeamObject>> FindTeamItems(List<int> teamIds)
    {
        var collection = _database.GetCollection<MyTeamObject>(collectionName);
        var filter = Builders<MyTeamObject>.Filter.AnyIn(x => x.TeamIds, teamIds);
        var result = await collection.FindAsync<MyTeamObject>(filter);
        var list = result.ToList();
        return list;
    }
