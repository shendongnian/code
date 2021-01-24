public class SeqIntIdGenerator<TEntity> : IIdGenerator
{
    var containerType = container.GetType();
    var database = (IMongoDatabase)containerType.GetProperty("Database").GetValue(container);
    var collectionNamespace = (CollectionNamespace)containerType.GetProperty("CollectionNamespace").GetValue(container);
    var idSequenceCollection = database.GetCollection<dynamic>("Counters");
    var filter = Builders<dynamic>.Filter.Eq("_id", collectionNamespace.CollectionName);
    var update = Builders<dynamic>.Update.Inc("Seq", 1);
    var options = new FindOneAndUpdateOptions<dynamic>
    {
        IsUpsert = true,
        ReturnDocument = ReturnDocument.After
    };
    return idSequenceCollection.FindOneAndUpdate(filter, update, options).Seq;
    }
    public bool IsEmpty(object id)
    {
        return (int)id == 0;
    }
}
