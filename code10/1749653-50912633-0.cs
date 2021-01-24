    public virtual ReplaceOneResult ReplaceOne(TDocument replacement, int projId)
    {
        var filter = Builders<TDocument>.Filter.Eq(x => x.ProjectId, projId);
        var result = Collection.ReplaceOne(filter, replacement, new UpdateOptions() { IsUpsert = false }, _cancellationToken);
        return result;
    }
